using AdminDashboard.Entity.Event.Querying.Common;
using MediatR;

namespace AdminDashboard.API.Reuqests.Client;

public record ClientGetPagerRequest : IRequest<QueryPagerResult>;