using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Models;
using MediatR;

namespace AdminDashboard.API.Reuqests;

public record ClientUpdateRequest(Client client) : IRequest<ClientCommandResult>;
