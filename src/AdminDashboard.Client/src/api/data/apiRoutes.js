class ApiRoutes {
    static base = `/api`
    
    static serviceRoute = {
        'snap' : '/service/snap'
    }

    static modelStructureRoute = {
        'client' : `/service/clientDisplay`,
        'payment' : `/service/paymentDisplay`,
        'currency' : '/service/currencyDisplay'
    }

    static accountRoutes = {
        'register' : `/authentication/register`,
        'login' : `/authentication/login`,
        'logout' : `/authentication/logout`,
        'getStatus': '/authentication/getStatus',
        'getRoles' : `/authentication/getRoles`,
        'update' : `/authentication/update`,
        'delete' : `/authentication/delete/{clientId}`
    }

    static clientRoute = {
        'getAll' : `/clients/getAll`,
        'getSingle' : `/clients/getSingle/{clientId}`,
        'getVolumed' : `/clients/getVolumed/{width}`
    }

    static paymentRoute = {
        'create' : `/payments/create`,
        'update' : `/payments/update`,
        'delete' : `/payments/delete/{paymentId}`,
        'getAll' : `/payments/getAll`,
        'getSingle' : `/payments/getSingle/{paymentId}`,
        'getLast' : `/payments/getLast/{width}`,
        'getHistory': `/payments/getHistory/{clientId}`
    }

    static currencyRoute = {
        'getStatus' : '/currency/getStatus',
        'getCurrencyList' : '/currency/getCurrencyList',
        'getCurrencyRate' : '/currency/getRate/{currencyCode}',
        'getPairRate' : '/currency/pair/{baseCode}/{targetCode}'
    }
}

export default ApiRoutes;