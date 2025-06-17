using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Reuqests.Payment;

public record PaymentDeleteRequest(int paymentId) : IRequest<PaymentCommandResult>;