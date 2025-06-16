using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Reuqests.Payment;

public record PaymentUpdateRequest(Payment payment) : IRequest<PaymentCommandResult>;