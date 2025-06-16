using AdminDashboard.Entity.Models;
using MediatR;

namespace AdminDashboard.API.Reuqests;

<<<<<<< HEAD
public record ClientCreateRequest(Client client) : IRequest<Client>;
=======
public record ClientCreateRequest(Client client) : IRequest<ClientCommandResult>;
>>>>>>> parent of 766d80f ([src] add PaymentHandler, update client and payment requests, add last range querying)
