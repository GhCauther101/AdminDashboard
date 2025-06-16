using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests;

public record PaymentGetAllRequest() : IRequest<PaymentQueryResult>;