using AdminDashboard.Entity.Dto;
using AdminDashboard.Entity.Event.Command;
using MediatR;

namespace AdminDashboard.API.Requests.Payment;

public record PaymentUpdateRequest(PaymentDto payment) : IRequest<PaymentCommandResult>;