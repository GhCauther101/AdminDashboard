using AdminDashboard.Entity.Dto;
using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Requests.Client;

public record ClientGetAllRequest() : IRequest<ClientWebReply<IEnumerable<ClientDto>>>;
