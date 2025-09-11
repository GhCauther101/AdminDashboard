using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Requests.Payment;

public record PaymentGetPageRequest(int start, int width) : IRequest<PaymentQueryResult>;