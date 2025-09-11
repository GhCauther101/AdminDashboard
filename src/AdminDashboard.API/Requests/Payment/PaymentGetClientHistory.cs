using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Requests.Payment;

public record PaymentGetClientHistory(Guid clientId) : IRequest<PaymentQueryResult>;