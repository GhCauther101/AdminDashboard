using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Requests.Payment;

public record PaymentGetSingleRequest(Guid paymentId) : IRequest<PaymentQueryResult>;
