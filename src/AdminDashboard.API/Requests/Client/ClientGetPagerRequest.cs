using AdminDashboard.Entity.Event.Querying.Common;
using MediatR;

namespace AdminDashboard.API.Requests.Client;

public record ClientGetPagerRequest : IRequest<QueryPagerResult>;