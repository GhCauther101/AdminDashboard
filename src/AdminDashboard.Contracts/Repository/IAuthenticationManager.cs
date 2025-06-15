using AdminDashboard.Entity.Dto;

namespace AdminDashboard.Contracts.Repository;

public interface IAuthenticationManager
{
    public Task<bool> ValidateUser(ClientForAuthentication clientForAuthentication);
    public Task<string> CreateToken();
}