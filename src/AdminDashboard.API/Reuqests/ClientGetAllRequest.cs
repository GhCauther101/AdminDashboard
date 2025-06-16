using AdminDashboard.Entity.Models;
using MediatR;

namespace AdminDashboard.API.Reuqests;

public record ClientGetAllRequest() : IRequest<IEnumerable<Client>>;
