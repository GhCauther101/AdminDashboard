using AdminDashboard.API.Reuqests;
using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.Repository.Managers;
using MediatR;

namespace AdminDashboard.API.Handlers;

public class ClientHandler
    : IRequestHandler<ClientCreateRequest, PaymentCommandResult>,
      IRequestHandler<ClientDeleteRequest, PaymentCommandResult>,
      IRequestHandler<ClientUpdateRequest, PaymentCommandResult>,
      IRequestHandler<ClientGetAllRequest, ClientQueryResult>,
      IRequestHandler<ClientGetPageRequest, ClientQueryResult>,
      IRequestHandler<ClientGetSingleRequest, ClientQueryResult>
{
    private readonly RepositoryManager _repositoryManager;

    public ClientHandler(RepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<PaymentCommandResult> Handle(ClientCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var commandParameters = new ClientCommandParameters(CommandType.CREATE, true, request.client);
            _repositoryManager.ClientRepository.CreateClient(commandParameters);
            await _repositoryManager.SaveChanges();
            return new PaymentCommandResult(CommandType.CREATE, true);
        }
        catch (Exception ex) 
        {
            return new PaymentCommandResult(CommandType.CREATE, false, ex);
        }
    }
    public async Task<PaymentCommandResult> Handle(ClientUpdateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var commandParameters = new ClientCommandParameters(CommandType.UPDATE, true, request.client);
            _repositoryManager.ClientRepository.UpdateClient(commandParameters);
            await _repositoryManager.SaveChanges();
            return new PaymentCommandResult(CommandType.UPDATE, true);
        }
        catch (Exception ex)
        {
            return new PaymentCommandResult(CommandType.UPDATE, false, ex);
        }
    }

    public async Task<PaymentCommandResult> Handle(ClientDeleteRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var queryParameters = new ClientQueryParameters(QueryParameterFunctionality.SINGLE, request.clientId);
            var clientQueryResult = await _repositoryManager.ClientRepository.Get(queryParameters);

            if (!clientQueryResult.IsSuccess || clientQueryResult.Entity is null || clientQueryResult.Range.Count() == 0)
                return new PaymentCommandResult(CommandType.DELETE, true);

            var commandParameters = new ClientCommandParameters(CommandType.DELETE,true, clientQueryResult.Entity);
            _repositoryManager.ClientRepository.DeleteClient(commandParameters);
            await _repositoryManager.SaveChanges();
            return new PaymentCommandResult(CommandType.DELETE, true);
        }
        catch (Exception ex)
        {
            return new PaymentCommandResult(CommandType.DELETE, false, ex);
        }
    }

    public async Task<ClientQueryResult> Handle(ClientGetAllRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var queryParameters = new ClientQueryParameters(QueryParameterFunctionality.GET_ALL);
            var clientQueryResult = await _repositoryManager.ClientRepository.Get(queryParameters);

            return clientQueryResult;
        }
        catch (Exception ex)
        {
            return new ClientQueryResult(false, exception: ex);
        }
    }
    

    public async Task<ClientQueryResult> Handle(ClientGetPageRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var queryParameters = new ClientQueryParameters(QueryParameterFunctionality.SINGLE, rangeStart: request.start, rangeWidth: request.width);
            var clientQueryResult = await _repositoryManager.ClientRepository.Get(queryParameters);

            return clientQueryResult;
        }
        catch (Exception ex)
        {
            return new ClientQueryResult(false, exception: ex);
        }
    }

    public async Task<ClientQueryResult> Handle(ClientGetSingleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var queryParameters = new ClientQueryParameters(QueryParameterFunctionality.SINGLE, entityId: request.clientId);
            var clientQueryResult = await _repositoryManager.ClientRepository.Get(queryParameters);

            return clientQueryResult;
        }
        catch (Exception ex)
        {
            return new ClientQueryResult(false, exception: ex);
        }
    }

    public async Task<ClientQueryResult> Handle(ClientGetLastRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var queryParameters = new ClientQueryParameters(QueryParameterFunctionality.SINGLE, entityId: request.lastRange);
            var clientQueryResult = await _repositoryManager.ClientRepository.Get(queryParameters);

            return clientQueryResult;
        }
        catch (Exception ex)
        {
            return new ClientQueryResult(false, exception: ex);
        }
    }
}
