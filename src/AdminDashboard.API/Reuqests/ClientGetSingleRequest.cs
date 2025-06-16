using AdminDashboard.Entity.Models;
using MediatR;

namespace AdminDashboard.API.Reuqests;

<<<<<<< HEAD
public record ClientGetSingleRequest(int clientId) : IRequest<Client>;
=======
public record ClientGetSingleRequest(int clientId) : IRequest<ClientQueryResult>;
>>>>>>> parent of 766d80f ([src] add PaymentHandler, update client and payment requests, add last range querying)
