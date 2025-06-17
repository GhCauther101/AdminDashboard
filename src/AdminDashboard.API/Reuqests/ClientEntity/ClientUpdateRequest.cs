using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests.Client;

public record ClientUpdateRequest(Entity.Models.Client client) : IRequest<ClientQueryResult>;
