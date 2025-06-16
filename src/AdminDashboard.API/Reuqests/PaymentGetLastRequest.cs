using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests;

public record PaymentGetLastRequest(int width) : IRequest<PaymentQueryResult>;