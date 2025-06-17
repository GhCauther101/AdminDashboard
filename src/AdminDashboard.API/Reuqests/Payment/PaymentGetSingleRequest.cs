using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests.Payment;

public record PaymentGetSingleRequest(int paymentId) : IRequest<PaymentQueryResult>;
