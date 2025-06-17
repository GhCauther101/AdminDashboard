<<<<<<< HEAD
﻿using AdminDashboard.API.Reuqests.Client;
=======
﻿using AdminDashboard.API.Reuqests;
using AdminDashboard.Contracts.Repository;
>>>>>>> a548314b977b38af18384394446f2da0199b7612
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
<<<<<<< HEAD
      IRequestHandler<ClientGetAllRequest, IEnumerable<Client>>,
      IRequestHandler<ClientGetPageRequest, IEnumerable<Client>>,
      IRequestHandler<ClientGetSingleRequest, Client>
=======
      IRequestHandler<ClientGetAllRequest, ClientQueryResult>,
      IRequestHandler<ClientGetPageRequest, ClientQueryResult>,
      IRequestHandler<ClientGetSingleRequest, ClientQueryResult>
>>>>>>> parent of 766d80f ([src] add PaymentHandler, update client and payment requests, add last range querying)
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
<<<<<<< HEAD


=======
>>>>>>> parent of 766d80f ([src] add PaymentHandler, update client and payment requests, add last range querying)
            return new ClientCommandResult(CommandType.CREATE, true);
        }
        catch (Exception ex) 
        {
            return new ClientCommandResult(CommandType.CREATE, false, ex);
        }
    }

<<<<<<< HEAD
    public async Task<ClientQueryResult> Handle(ClientDeleteRequest request, CancellationToken cancellationToken)
=======
    public async Task<ClientCommandResult> Handle(ClientDeleteRequest request, CancellationToken cancellationToken)
>>>>>>> parent of 766d80f ([src] add PaymentHandler, update client and payment requests, add last range querying)
    {
        var queryParameters = new ClientQueryParameters
        {
            Functionality = QueryParameterFunctionality.SINGLE,
            EntityId = request.clientId
        };

<<<<<<< HEAD
        var clientQueryResult = await _repositoryManager.ClientRepository.Get(queryParameters);
=======
            if (!clientQueryResult.IsSuccess || clientQueryResult.Entity is null || clientQueryResult.Range.Count() == 0)
                return new ClientCommandResult(CommandType.DELETE, true);

            var commandParameters = new ClientCommandParameters(CommandType.DELETE,true, clientQueryResult.Entity);
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
            var commandParameters = new ClientCommandParameters(CommandType.UPDATE, true, request.client);
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
>>>>>>> parent of 766d80f ([src] add PaymentHandler, update client and payment requests, add last range querying)

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
<<<<<<< HEAD

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
=======
>>>>>>> parent of 766d80f ([src] add PaymentHandler, update client and payment requests, add last range querying)
}
