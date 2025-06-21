using AdminDashboard.Entity.Dto;
using AdminDashboard.Entity.Models;

namespace AdminDashboard.Contracts.Repository;

public interface IAuthenticationManager
{
    public Task<bool> ValidateUser(ClientForAuthorization client);

    public Task<string> CreateToken();
}