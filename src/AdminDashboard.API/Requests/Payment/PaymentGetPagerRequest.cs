using AdminDashboard.Entity.Event.Querying.Common;
using MediatR;

namespace AdminDashboard.API.Requests.Payment;

public class PaymentGetPagerRequest : IRequest<QueryPagerResult>;
