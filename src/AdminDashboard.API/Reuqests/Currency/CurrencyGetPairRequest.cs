using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI.Models.Reply;
using MediatR;

namespace AdminDashboard.API.Reuqests.Currency;

public record CurrencyGetPairRequest(string BaseCode, string TargetCode) : IRequest<CurrencyWebReply<CurrencyPairReply>>;