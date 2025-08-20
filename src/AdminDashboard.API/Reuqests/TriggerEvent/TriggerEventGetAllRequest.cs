using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests.TriggerEvent;

public record TriggerEventGetAllRequest() : IRequest<LogEventQueryResult>;
