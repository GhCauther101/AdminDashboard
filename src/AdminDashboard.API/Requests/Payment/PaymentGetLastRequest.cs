using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Requests.Payment;

public record PaymentGetLastRequest(int width) : IRequest<PaymentQueryResult>;