using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Requests.TriggerEvent;

public record TriggerEventDeleteRequest(Entity.Event.Base.TriggerEvent triggerEvent) : IRequest<LogEventQueryResult>;
