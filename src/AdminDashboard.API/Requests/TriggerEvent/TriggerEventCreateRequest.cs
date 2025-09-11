using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Requests.TriggerEvent;

public record TriggerEventCreateRequest(Entity.Event.Base.TriggerEvent triggerEvent) : IRequest<LogEventQueryResult>;