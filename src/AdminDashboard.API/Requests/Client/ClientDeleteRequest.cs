using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Requests.Client;

public record ClientDeleteRequest(Guid clientId) : IRequest<ClientCommandResult>;