using AdminDashboard.API.Reuqests.Client;
using AdminDashboard.Entity.Dto;
using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.Entity.Models;
using AdminDashboard.Repository.Managers;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AdminDashboard.API.Handlers;

public class ClientHandler
    : IRequestHandler<ClientCreateRequest, ClientCommandResult>,
      IRequestHandler<ClientDeleteRequest, ClientCommandResult>,
      IRequestHandler<ClientUpdateRequest, ClientCommandResult>,
      IRequestHandler<ClientGetAllRequest, ClientQueryResult>,
      IRequestHandler<ClientGetPageRequest, ClientQueryResult>,
      IRequestHandler<ClientGetSingleRequest, ClientQueryResult>,
      IRequestHandler<ClientGetPagerRequest, QueryPagerResult>
{
    private readonly IMapper _mapper;
    private readonly RepositoryManager _repositoryManager;
    private readonly AuthenticationManager _authenticationManager;
    private readonly UserManager<Client> _userManager;

    public ClientHandler(
        IMapper mapper,
        RepositoryManager repositoryManager,
        AuthenticationManager authenticationManager,
        UserManager<Client> userManager)
    {
        _mapper = mapper;
        _repositoryManager = repositoryManager;
        _authenticationManager = authenticationManager;
        _userManager = userManager;
    }

    public async Task<ClientCommandResult> Handle(ClientCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var commandParameters = new ClientCommandParameters(CommandType.CREATE, true, request.client);

            _repositoryManager.ClientRepository.CreateClient(commandParameters);
            await _repositoryManager.SaveChanges();

            return new ClientCommandResult(CommandType.CREATE, true);
        }
        catch (Exception ex) 
        {
            return new ClientCommandResult(CommandType.CREATE, false, ex);
        }
    }

    public async Task<ClientCommandResult> Handle(ClientDeleteRequest request, CancellationToken cancellationToken)
    {
        try 
        { 
            var queryParameters = new ClientQueryParameters
            {
                Functionality = QueryParameterFunctionality.SINGLE,
                EntityId = request.clientId
            };

            var clientQueryResult = await _repositoryManager.ClientRepository.Get(queryParameters);
            if (!clientQueryResult.IsSuccess || clientQueryResult.Entity is null)
                return new ClientCommandResult(CommandType.DELETE, false);

            var commandParameters = new ClientCommandParameters(CommandType.DELETE, true, clientQueryResult.Entity);
            _repositoryManager.ClientRepository.DeleteClient(commandParameters);
            await _repositoryManager.SaveChanges();
            return new ClientCommandResult(CommandType.DELETE, true);
        }
        catch (Exception ex)
        {
            return new ClientCommandResult(CommandType.DELETE, false, ex);
        }
    }

    public async Task<ClientCommandResult> Handle(ClientUpdateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var clientInstance = await _userManager.FindByIdAsync(request.clientUpdate.ClientId);
            var newRoles = new string[] { request.clientUpdate.Role };
            await _authenticationManager.UpdateClientRoles(clientInstance, newRoles);
            var updateClientInstance = await _authenticationManager.ApplyClientUpdates(clientInstance, request.clientUpdate);

            var commandParameters = new ClientCommandParameters(CommandType.UPDATE, true, updateClientInstance);
            await _authenticationManager.UpdateClientPassword(commandParameters.Data);

            _repositoryManager.ClientRepository.UpdateClient(commandParameters);
            await _repositoryManager.SaveChanges();
            return new ClientCommandResult(CommandType.UPDATE, true);
        }
        catch (Exception ex)
        {
            return new ClientCommandResult(CommandType.UPDATE, false, ex);
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

    public async Task<QueryPagerResult> Handle(ClientGetPagerRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var clientQueryPager = await _repositoryManager.ClientRepository.GetPager();

            return clientQueryPager;
        }
        catch (Exception ex)
        {
            return new QueryPagerResult(false, exception: ex);
        }
    }
}
