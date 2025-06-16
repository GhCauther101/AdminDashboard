using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests;

public record ClientGetSingleRequest(int clientId) : IRequest<ClientQueryResult>;
