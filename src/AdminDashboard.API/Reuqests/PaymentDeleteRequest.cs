using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Reuqests;

public record PaymentDeleteRequest(int paymentId) : IRequest<PaymentCommandResult>;