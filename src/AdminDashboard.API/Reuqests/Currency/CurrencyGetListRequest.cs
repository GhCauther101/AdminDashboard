using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI.Models.Reply;
using MediatR;

namespace AdminDashboard.API.Reuqests.Currency;

public record CurrencyGetListRequest() : IRequest<CurrencyWebReply<CurrencyCodesReply>>;

public record CurrencyGetRateRequest(string RateCode) : IRequest<CurrencyWebReply<CurrencyRateReply>>;

public record CurrencyGetPairRequest(string BaseCode, string TargetCode) : IRequest<CurrencyWebReply<CurrencyPairReply>>;