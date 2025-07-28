namespace AdminDashboard.API.Routes;

public static class ApiRoutes
{
    public static class ServiceRoutes
    {
        private const string controllerBase = "/structure";

        public const string GetClientStructure = controllerBase + "/clientDisplay";

        public const string GetPaymentStructure = controllerBase + "/paymentDisplay";
    }

    public static class AccountRoutes
    {
        private const string controllerBase = "/authentication";

        public const string ControllerBase = controllerBase;

        public const string GetRoles = controllerBase + "/getRoles";

        public const string Register = controllerBase + "/register";

        public const string Login = controllerBase + "/login";

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

        public const string GetLastRange = controllerBase + "/getLastRange";

        public const string GetPager = controllerBase + "/getPager";
    }
}
