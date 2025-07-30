using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests.Client;

public class ClientGetPagerRequest : IRequest<QueryPagerResult>;