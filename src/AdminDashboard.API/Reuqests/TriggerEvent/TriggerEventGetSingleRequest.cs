using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests.TriggerEvent;

public record TriggerEventGetSingleRequest(int clientId) : IRequest<TriggerEventQueryResult>;
