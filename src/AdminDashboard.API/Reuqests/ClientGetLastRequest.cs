using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests;

public record ClientGetLastRequest(int lastRange) : IRequest<ClientQueryResult>;