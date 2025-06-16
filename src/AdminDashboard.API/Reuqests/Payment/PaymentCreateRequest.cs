using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Reuqests.Payment;

public record PaymentCreateRequest(Entity.Models.Payment payment) : IRequest<PaymentCommandResult>;