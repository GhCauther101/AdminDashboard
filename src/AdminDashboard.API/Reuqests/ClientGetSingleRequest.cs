using AdminDashboard.Entity.Models;
using MediatR;

namespace AdminDashboard.API.Reuqests;

public record ClientGetSingleRequest(int clientId) : IRequest<Client>;
