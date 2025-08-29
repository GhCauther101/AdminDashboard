using AdminDashboard.Contracts.Repository;

namespace AdminDashboard.Repository.Context;

public class DbContextBus : IDbContextBus
{
    private readonly IdentityContext _identityContext;

    public DbContextBus(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public IdentityContext IdentityContextInstance => _identityContext;
}
