using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Reuqests.Client;

public record ClientUpdateRequest(AdminDashboard.Entity.Models.Client client) : IRequest<PaymentCommandResult>;
