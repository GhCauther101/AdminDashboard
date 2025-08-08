using AdminDashboard.Entity.Dto;
using AdminDashboard.Entity.Event.Querying;
using MediatR;

namespace AdminDashboard.API.Reuqests.Client;

public record ClientGetVolumedRequest(int width) : IRequest<ClientWebReply<IEnumerable<ClientDto>>>;