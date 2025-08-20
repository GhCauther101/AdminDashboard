using AdminDashboard.API.Remote;
using AdminDashboard.API.Reuqests.Currency;
using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.ExchangeService.Sdk.ExchangeRateAPI.Models.Reply;
using MediatR;

namespace AdminDashboard.API.Handlers;

public class CurrencyHandler :
    IRequestHandler<ServiceGetStatusRequest, CurrencyWebReply<ServiceStatusReply>>,
    IRequestHandler<CurrencyGetListRequest, CurrencyWebReply<CurrencyCodesReply>>,
    IRequestHandler<CurrencyGetRateRequest, CurrencyWebReply<CurrencyRateReply>>,
    IRequestHandler<CurrencyGetPairRequest, CurrencyWebReply<CurrencyPairReply>>
{
    private RemoteClient _remoteClient;

    public CurrencyHandler(RemoteClient remoteClient)
    {
        _remoteClient = remoteClient;        
    }

    public async Task<CurrencyWebReply<ServiceStatusReply>> Handle(ServiceGetStatusRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var reply = await _remoteClient.GetServiceAliveStatus();
            return new CurrencyWebReply<ServiceStatusReply>(true, reply);
        }
        catch (Exception ex)
        {
            return new CurrencyWebReply<ServiceStatusReply>(false, ex);
        }
    }

    public async Task<CurrencyWebReply<CurrencyCodesReply>> Handle(CurrencyGetListRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var reply = await _remoteClient.GetCurrencyListAsync();
            return new CurrencyWebReply<CurrencyCodesReply>(true, reply);
        }
        catch (Exception ex)
        {
            return new CurrencyWebReply<CurrencyCodesReply>(false, ex);
        }
    }

    public async Task<CurrencyWebReply<CurrencyRateReply>> Handle(CurrencyGetRateRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var reply = await _remoteClient.GetCurrencyRateAsync(request.RateCode);
            return new CurrencyWebReply<CurrencyRateReply>(true, reply);
        }
        catch (Exception ex)
        {
            return new CurrencyWebReply<CurrencyRateReply>(false, ex);
        }
    }

    public async Task<CurrencyWebReply<CurrencyPairReply>> Handle(CurrencyGetPairRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var reply = await _remoteClient.GetPairRateAsync(request.BaseCode, request.TargetCode);
            return new CurrencyWebReply<CurrencyPairReply>(true, reply);
        }
        catch (Exception ex)
        {
            return new CurrencyWebReply<CurrencyPairReply>(false, ex);
        }
    }
}
