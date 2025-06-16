using AdminDashboard.Entity.Models;
using MediatR;

namespace AdminDashboard.API.Reuqests;

public record ClientGetPageRequest(int start, int width) : IRequest<IEnumerable<Client>>;