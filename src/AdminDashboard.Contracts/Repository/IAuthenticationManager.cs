using AdminDashboard.Entity.Dto;

namespace AdminDashboard.Contracts.Repository;

public interface IAuthenticationManager
{
    public Task<bool> ValidateUser(ClientForAuthorization client);

    public Task<string> CreateToken();
}