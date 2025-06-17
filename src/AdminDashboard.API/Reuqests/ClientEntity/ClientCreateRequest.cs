using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Reuqests.Client;

public record ClientCreateRequest(Entity.Models.Client client) : IRequest<ClientCommandResult>;