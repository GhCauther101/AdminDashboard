using Grpc.Net.Client;
using static AdminDashboard.ExchangeService.CurrencyExchangeService;

namespace AdminDashboard.API.Remote.Services;

public class CurrencyServiceClient : IDisposable
{
    private GrpcChannel _channel;
    private CurrencyExchangeServiceClient _exchangeService;

    public CurrencyServiceClient()
    {}

    public CurrencyServiceClient(string address)
    {
        var uri = new Uri(address);
        this.LaunchClientInstance(uri);
    }

    public CurrencyServiceClient(Uri uriAddress)
    {
        this.LaunchClientInstance(uriAddress);
    }

    public CurrencyExchangeServiceClient? ExchangeService => _exchangeService;

    private void LaunchClientInstance(Uri address)
    {
        _channel = GrpcChannel.ForAddress(address);
        _exchangeService = new CurrencyExchangeServiceClient(_channel);
    }

    public void ConnectToInstance(string address)
    {
        var uri = new Uri(address);
        this.LaunchClientInstance(uri);
    }

    public void ConnectToInstance(Uri uriAddress)
    {
        this.LaunchClientInstance(uriAddress);
    }

    public void Dispose()
    {
        _exchangeService = null;
        _channel.Dispose();
    }
}