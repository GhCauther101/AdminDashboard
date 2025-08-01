using AdminDashboard.Entity.Dto;
using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Reuqests.Payment;

public record PaymentCreateRequest(PaymentDto payment) : IRequest<PaymentCommandResult>;