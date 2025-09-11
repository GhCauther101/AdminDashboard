using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Requests.TriggerEvent;

public record TriggerEventGetSingleRequest(int clientId) : IRequest<LogEventQueryResult>;
