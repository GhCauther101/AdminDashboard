using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Requests.Client;

public record ClientCreateRequest(Entity.Models.Client client) : IRequest<ClientCommandResult>;