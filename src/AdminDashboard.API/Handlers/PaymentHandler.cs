using AdminDashboard.API.Reuqests.Payment;
using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.Entity.Models;
using AdminDashboard.Repository.Managers;
using AutoMapper;
using MediatR;

namespace AdminDashboard.API.Handlers;

public class PaymentHandler :
      IRequestHandler<PaymentCreateRequest, PaymentCommandResult>,
      IRequestHandler<PaymentUpdateRequest, PaymentCommandResult>,
      IRequestHandler<PaymentDeleteRequest, PaymentCommandResult>,
      IRequestHandler<PaymentGetAllRequest, PaymentQueryResult>,
      IRequestHandler<PaymentGetLastRequest, PaymentQueryResult>,
      IRequestHandler<PaymentGetSingleRequest, PaymentQueryResult>,
      IRequestHandler<PaymentGetPageRequest, PaymentQueryResult>,
      IRequestHandler<PaymentGetPagerRequest, QueryPagerResult>
{
    private readonly IMapper _mapper;
    private readonly RepositoryManager _repositoryManager;

    public PaymentHandler(IMapper mapper, RepositoryManager repositoryManager)
    {
        _mapper = mapper;
        _repositoryManager = repositoryManager;
    }

    public async Task<PaymentCommandResult> Handle(PaymentCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var paymentInstance = _mapper.Map<Payment>(request.payment);
            if (!paymentInstance.SourceClientId.Equals(Guid.Empty)  && !paymentInstance.DestinationClientId.Equals(Guid.Empty))
            {
                var sourceQueryParameters = new ClientQueryParameters<string>(QueryParameterFunctionality.SINGLE, entityId: paymentInstance.SourceClientId);
                var sourceClient = await _repositoryManager.ClientRepository.Get(sourceQueryParameters);
                var destinationQueryParameters = new ClientQueryParameters<string>(QueryParameterFunctionality.SINGLE, entityId: paymentInstance.DestinationClientId);
                var destinationClient = await _repositoryManager.ClientRepository.Get(destinationQueryParameters);
                
                paymentInstance.SourceClient = sourceClient.Entity;
                paymentInstance.DestinationClient = destinationClient.Entity;
            }

            var commandParameters = new PaymentCommandParameters(CommandType.CREATE, true, paymentInstance);
            _repositoryManager.PaymentRepository.CreatePayment(commandParameters);
            await _repositoryManager.SaveChanges();
            return new PaymentCommandResult(CommandType.CREATE, true);
        }
        catch (Exception ex)
        {
            return new PaymentCommandResult(CommandType.CREATE, false, ex);
        }
    }

    public async Task<PaymentCommandResult> Handle(PaymentUpdateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var paymentInstance = _mapper.Map<Payment>(request.payment);
            if (!paymentInstance.SourceClientId.Equals(Guid.Empty) && !paymentInstance.DestinationClientId.Equals(Guid.Empty))
            {
                var sourceQueryParameters = new ClientQueryParameters<string>(QueryParameterFunctionality.SINGLE, entityId: paymentInstance.SourceClientId);
                var sourceClient = await _repositoryManager.ClientRepository.Get(sourceQueryParameters);
                var destinationQueryParameters = new ClientQueryParameters<string>(QueryParameterFunctionality.SINGLE, entityId: paymentInstance.DestinationClientId);
                var destinationClient = await _repositoryManager.ClientRepository.Get(destinationQueryParameters);

                paymentInstance.SourceClient = sourceClient.Entity;
                paymentInstance.DestinationClient = destinationClient.Entity;
            }

            var commandParameters = new PaymentCommandParameters(CommandType.UPDATE, true, paymentInstance);
            _repositoryManager.PaymentRepository.UpdatePayment(commandParameters);
            await _repositoryManager.SaveChanges();
            return new PaymentCommandResult(CommandType.UPDATE, true);
        }
        catch (Exception ex)
        {
            return new PaymentCommandResult(CommandType.UPDATE, false, ex);
        }
    }

    public async Task<PaymentCommandResult> Handle(PaymentDeleteRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var queryParameters = new PaymentQueryParameters(QueryParameterFunctionality.SINGLE, request.paymentId);
            var paymentQueryResult = await _repositoryManager.PaymentRepository.Get(queryParameters);

            if (!paymentQueryResult.IsSuccess || paymentQueryResult.Entity is null || paymentQueryResult.Range.Count() == 0)
                return new PaymentCommandResult(CommandType.DELETE, true);

            var commandParameters = new PaymentCommandParameters(CommandType.DELETE, true, paymentQueryResult.Entity);
            _repositoryManager.PaymentRepository.DeletePayment(commandParameters);
            await _repositoryManager.SaveChanges();
            return new PaymentCommandResult(CommandType.DELETE, true);
        }
        catch (Exception ex)
        {
            return new PaymentCommandResult(CommandType.DELETE, false, ex);
        }
    }

    public async Task<PaymentQueryResult> Handle(PaymentGetAllRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var queryParameters = new PaymentQueryParameters(QueryParameterFunctionality.GET_ALL);
            var clientQueryResult = await _repositoryManager.PaymentRepository.Get(queryParameters);

            return clientQueryResult;
        }
        catch (Exception ex)
        {
            return new PaymentQueryResult(false, exception: ex);
        }
    }

    public async Task<PaymentQueryResult> Handle(PaymentGetLastRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var queryParameters = new PaymentQueryParameters(QueryParameterFunctionality.LAST, lastWidth: request.width);
            var clientQueryResult = await _repositoryManager.PaymentRepository.Get(queryParameters);

            return clientQueryResult;
        }
        catch (Exception ex)
        {
            return new PaymentQueryResult(false, exception: ex);
        }
    }

    public async Task<PaymentQueryResult> Handle(PaymentGetSingleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var queryParameters = new PaymentQueryParameters(QueryParameterFunctionality.SINGLE, entityId: request.paymentId);
            var clientQueryResult = await _repositoryManager.PaymentRepository.Get(queryParameters);

            return clientQueryResult;
        }
        catch (Exception ex)
        {
            return new PaymentQueryResult(false, exception: ex);
        }
    }

    public async Task<PaymentQueryResult> Handle(PaymentGetPageRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var queryParameters = new PaymentQueryParameters(QueryParameterFunctionality.SINGLE, rangeStart: request.start, rangeWidth: request.width);
            var clientQueryResult = await _repositoryManager.PaymentRepository.Get(queryParameters);

            return clientQueryResult;
        }
        catch (Exception ex)
        {
            return new PaymentQueryResult(false, exception: ex);
        }
    }

    public async Task<QueryPagerResult> Handle(PaymentGetPagerRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var clientQueryPager = await _repositoryManager.PaymentRepository.GetPager();

            return clientQueryPager;
        }
        catch (Exception ex)
        {
            return new QueryPagerResult(false, exception: ex);
        }
    }
}
