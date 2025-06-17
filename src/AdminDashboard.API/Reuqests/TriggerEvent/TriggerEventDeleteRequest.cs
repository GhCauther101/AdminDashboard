using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests.TriggerEvent;

public record TriggerEventDeleteRequest(Entity.Event.Base.TriggerEvent triggerEvent) : IRequest<TriggerEventQueryResult>;
