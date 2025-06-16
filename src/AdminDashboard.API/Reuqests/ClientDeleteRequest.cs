using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Models;
using MediatR;

namespace AdminDashboard.API.Reuqests;

public record ClientDeleteRequest(int clientId) : IRequest<ClientCommandResult>;
