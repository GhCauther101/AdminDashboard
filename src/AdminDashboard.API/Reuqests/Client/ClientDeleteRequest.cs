using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Reuqests.Client;

public record ClientDeleteRequest(int clientId) : IRequest<ClientCommandResult>;
