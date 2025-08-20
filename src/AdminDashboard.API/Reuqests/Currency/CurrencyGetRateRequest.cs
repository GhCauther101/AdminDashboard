using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI.Models.Reply;
using MediatR;

namespace AdminDashboard.API.Reuqests.Currency;

public record CurrencyGetRateRequest(string RateCode) : IRequest<CurrencyWebReply<CurrencyRateReply>>;
