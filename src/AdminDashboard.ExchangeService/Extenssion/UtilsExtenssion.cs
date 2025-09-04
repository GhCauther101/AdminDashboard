namespace AdminDashboard.ExchangeService.Extenssion;

public static class UtilsExtenssion
{
    public static CertCredentials ResolveCertificateCreadentials(this IConfiguration configuration)
    {
        var deployType = configuration.GetSection("DeployType").Value.ToString();

        if (deployType == "host")
        {
            var certPath = configuration.GetSection("CertPath").Value.ToString();
            var certPassword = configuration.GetSection("CertPassword").Value.ToString();
            return new CertCredentials(certPath, certPassword);
        }
        else if (deployType == "container")
        {
            var certPath = configuration["ASPNETCORE_Kestrel:Certificates:Default:Path"];
            var certPassword = configuration["ASPNETCORE_Kestrel:Certificates:Default:Password"];
            return new CertCredentials(certPath, certPassword);
        }
        else throw new Exception("Could not reoolve certificateCredentials");
    }
}