using MediatR;

namespace AdminDashboard.API.Requests.TriggerEvent;

public record TriggerEventGetPageRequest(int start, int width) : IRequest<TriggerEventGetPageRequest>;
