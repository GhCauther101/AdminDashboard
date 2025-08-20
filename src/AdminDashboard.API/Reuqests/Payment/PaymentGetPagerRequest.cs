using AdminDashboard.Entity.Event.Querying.Common;
using MediatR;

namespace AdminDashboard.API.Reuqests.Payment;

public class PaymentGetPagerRequest : IRequest<QueryPagerResult>;
