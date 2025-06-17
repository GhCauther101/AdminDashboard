using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests.Payment;

public record PaymentGetLastRequest(int width) : IRequest<PaymentQueryResult>;