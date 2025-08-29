using System.Net;
using Grpc.Net.Client;
using static AdminDashboard.ExchangeService.CurrencyExchangeService;

namespace AdminDashboard.API.Remote.Services;

public class CurrencyServiceClient : IDisposable
{
    private GrpcChannel _channel;
    private CurrencyExchangeServiceClient _exchangeService;

    public CurrencyServiceClient()
    {}

    private void LaunchClientInstance(Uri address)
    {        
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };

        var client = new HttpClient(handler);
        
        _channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions {HttpClient = client, HttpVersion = HttpVersion.Version20, HttpVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher});
        _exchangeService = new CurrencyExchangeServiceClient(_channel);
    }


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