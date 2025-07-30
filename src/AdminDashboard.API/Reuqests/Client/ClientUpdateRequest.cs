using AdminDashboard.Entity.Dto;
using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Reuqests.Client;

public record ClientUpdateRequest(ClientForUpdate clientUpdate) : IRequest<ClientCommandResult>;