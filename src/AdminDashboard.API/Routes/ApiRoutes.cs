namespace AdminDashboard.API.Routes;

public static class ApiRoutes
{
    public static class AccountRoutes
    {
        private const string controllerBase = "/api/login";

        public const string ControllerBase = controllerBase;

        public const string GetToken = controllerBase + "/token";
    }

    public static class ClientRoutes
    {
        private const string controllerBase = "/api/clients";

        public const string ControllerBase = controllerBase;

        public const string CreateClient = controllerBase + "/create";

        public const string UpdateClient = controllerBase + "/update";

        public const string DeleteClient = controllerBase + "/delete/{clientId}";

        public const string GetAllClients = controllerBase + "/getAll";

        public const string GetSinge = controllerBase + "/getSingle/{clientId}";
    }

    public static class PaymentRoutes
    {
        private const string controllerBase = "/api/payments";

        public const string ControllerBase = controllerBase;

        public const string CreateClient = controllerBase + "/create";

        public const string UpdateClient = controllerBase + "/update";

        public const string DeleteClient = controllerBase + "/delete/{clientId}";

        public const string GetAllClient = controllerBase + "/getAll";

        public const string GetSinge = controllerBase + "/getSingle/{clientId}";

        public const string GetLastRange = controllerBase + "/getLastRange";
    }

}
