using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Reuqests.Payment;

public record PaymentUpdateRequest(Entity.Models.Payment payment) : IRequest<PaymentCommandResult>;