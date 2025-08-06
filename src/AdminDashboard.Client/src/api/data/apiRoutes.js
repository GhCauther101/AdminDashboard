class ApiRoutes {
    static base = `/api`
    
    static modelStructureRoute = {
        'client' : `/structure/clientDisplay`,
        'payment' : `/structure/paymentDisplay`
    }

    static accountRoutes = {
        'register' : `/authentication/register`,
        'login' : `/authentication/login`,
        'logout' : `/authentication/logout`,
        'getRoles' : `/authentication/getRoles`,
        'update' : `/authentication/update`,
        'delete' : `/authentication/delete/{clientId}`
    }

    static clientRoute = {
        'getAll' : `/clients/getAll`,
        'getSingle' : `/clients/getSingle/{clientId}`
    }

    static paymentRoute = {
        'create' : `/payments/create`,
        'update' : `/payments/update`,
        'delete' : `/payments/delete/{paymentId}`,
        'getAll' : `/payments/getAll`,
        'getSingle' : `/payments/getSingle/{paymentId}`,
        'getSingle' : `/payments/getlastRange`
    }
}

export default ApiRoutes;