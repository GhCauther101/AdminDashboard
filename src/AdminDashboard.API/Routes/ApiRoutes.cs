namespace AdminDashboard.API.Routes;

public static class ApiRoutes
{
    public static class ServiceRoutes
    {
        private const string controllerBase = "/structure";

        public const string GetClientStructure = controllerBase + "/clientDisplay";

        public const string GetPaymentStructure = controllerBase + "/paymentDisplay";

        public const string GetSnap = controllerBase + "/snap";
    }

    public static class AccountRoutes
    {
        private const string controllerBase = "/authentication";

        public const string ControllerBase = controllerBase;

        public const string GetRoles = controllerBase + "/getRoles";

        public const string Register = controllerBase + "/register";

        public const string Login = controllerBase + "/login";

        public const string Logout = controllerBase + "/logout";

        public const string GetStatus = controllerBase + "/getStatus";

        public const string UpdateClient = controllerBase + "/update";

        public const string DeleteClient = controllerBase + "/delete/{clientId}";
    }

    public static class ClientRoutes
    {
        private const string controllerBase = "/clients";

        public const string ControllerBase = controllerBase;

        public const string GetAll = controllerBase + "/getAll";

        public const string GetSinge = controllerBase + "/getSingle/{clientId}";

        public const string GetPager = controllerBase + "/getPager";

        public const string GetVolumed = controllerBase + "/getVolumed/{width}";
    }

    public static class PaymentRoutes
    {
        private const string controllerBase = "/payments";

        public const string ControllerBase = controllerBase;

        public const string CreatePayment = controllerBase + "/create";

        public const string UpdatePayment = controllerBase + "/update";

        public const string DeletePayment = controllerBase + "/delete/{paymentId}";

        public const string GetAll = controllerBase + "/getAll";

        public const string GetSinge = controllerBase + "/getSingle/{paymentId}";

        public const string GetLastRange = controllerBase + "/getLast/{width}";

        public const string GetHistory = controllerBase + "/getHistory/{clientId}";

        public const string GetPager = controllerBase + "/getPager";
    }
}
