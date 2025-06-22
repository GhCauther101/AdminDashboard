namespace AdminDashboard.API.Scopes;

public static class RoleScopes
{
    public const string AdminScope = "admin";
    public const string ManagerScope = "admin,manager";
    public const string UserScope = "admin,manager,user";
}
