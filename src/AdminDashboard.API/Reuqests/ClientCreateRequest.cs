using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Models;
using MediatR;

namespace AdminDashboard.API.Reuqests;

public record ClientCreateRequest(Client client) : IRequest<ClientCommandResult>;