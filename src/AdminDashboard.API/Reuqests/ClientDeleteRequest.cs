using AdminDashboard.Entity.Models;
using MediatR;

namespace AdminDashboard.API.Reuqests;

<<<<<<< HEAD
public record ClientDeleteRequest(int clientId) : IRequest;
=======
public record ClientDeleteRequest(int clientId) : IRequest<ClientCommandResult>;
>>>>>>> parent of 766d80f ([src] add PaymentHandler, update client and payment requests, add last range querying)
