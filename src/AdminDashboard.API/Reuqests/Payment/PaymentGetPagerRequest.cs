using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests.Payment;

public class PaymentGetPagerRequest : IRequest<QueryPagerResult>;
