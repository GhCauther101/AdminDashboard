using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Reuqests.Client;

public record ClientDeleteRequest(Guid clientId) : IRequest<ClientCommandResult>;