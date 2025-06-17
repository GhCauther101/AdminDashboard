using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Reuqests.Client;

public record ClientUpdateRequest(Entity.Models.Client client) : IRequest<ClientCommandResult>;
