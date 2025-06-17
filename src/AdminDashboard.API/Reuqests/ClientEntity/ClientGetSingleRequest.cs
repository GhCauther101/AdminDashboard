using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests.Client;

public record ClientGetSingleRequest(int clientId) : IRequest<ClientQueryResult>;