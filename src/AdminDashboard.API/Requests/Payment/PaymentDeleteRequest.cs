using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Requests.Payment;

public record PaymentDeleteRequest(int paymentId) : IRequest<PaymentCommandResult>;