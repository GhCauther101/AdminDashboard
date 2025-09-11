using AdminDashboard.Entity.Dto;
using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Requests.Client;

public record ClientGetPageRequest(int start, int width) : IRequest<ClientWebReply<IEnumerable<ClientDto>>>;