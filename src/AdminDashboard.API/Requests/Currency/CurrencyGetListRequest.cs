using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI.Models.Reply;
using MediatR;

namespace AdminDashboard.API.Requests.Currency;

public record CurrencyGetListRequest() : IRequest<CurrencyWebReply<CurrencyCodesReply>>;