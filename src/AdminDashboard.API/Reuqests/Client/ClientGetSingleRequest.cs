using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests.Client;

public record ClientGetSingleRequest(Guid clientId) : IRequest<ClientQueryResult>;