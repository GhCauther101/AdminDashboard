using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Requests.Client;

public record ClientGetLastRequest(int lastRange) : IRequest<ClientQueryResult>;