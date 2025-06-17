using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests.Payment;

public record PaymentGetAllRequest() : IRequest<PaymentQueryResult>;