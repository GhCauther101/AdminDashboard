using AdminDashboard.API.Reuqests;
using AdminDashboard.Contracts.Repository;
using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.Entity.Models;
using AdminDashboard.Repository.Managers;
using MediatR;

namespace AdminDashboard.API.Handlers;

public class ClientHandler
    : IRequestHandler<ClientCreateRequest, ClientCommandResult>,
      IRequestHandler<ClientDeleteRequest, ClientCommandResult>,
      IRequestHandler<ClientUpdateRequest, ClientCommandResult>,
      IRequestHandler<ClientGetAllRequest, IEnumerable<Client>>,
      IRequestHandler<ClientGetPageRequest, IEnumerable<Client>>,
      IRequestHandler<ClientGetSingleRequest, Client>
{
    private readonly RepositoryManager _repositoryManager;

    public ClientHandler(RepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<ClientCommandResult> Handle(ClientCreateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var commandParameters = new ClientCommandParameters(CommandType.CREATE, true, request.client);

            var queryParameters = new ClientQueryParameters(QueryParameterFunctionality.SINGLE, true, request.client.Id);

            _repositoryManager.ClientRepository.CreateClient(commandParameters);
            await _repositoryManager.SaveChanges();


            return new ClientCommandResult(CommandType.CREATE, true);
        }
        catch (Exception ex) 
        {
            return new ClientCommandResult(CommandType.CREATE, false, ex);
        }
    }

    public async Task<ClientQueryResult> Handle(ClientDeleteRequest request, CancellationToken cancellationToken)
    {
        var queryParameters = new ClientQueryParameters
        {
            Functionality = QueryParameterFunctionality.SINGLE,
            EntityId = request.clientId
        };

        var clientQueryResult = await _repositoryManager.ClientRepository.Get(queryParameters);

        if (!clientQueryResult.IsSuccess)
            return clientQueryResult;

        var commandParameters = new ClientCommandParameters
        {
            Command = CommandType.DELETE,
            IsSingle = true,
            Data = clientQueryResult.Entity
        };

        _repositoryManager.ClientRepository.DeleteClient(commandParameters);
        return new ClientQueryResult();
    }

    public Task<Client> Handle(ClientUpdateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Client>> Handle(ClientGetAllRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Client>> Handle(ClientGetPageRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Client> Handle(ClientGetSingleRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
