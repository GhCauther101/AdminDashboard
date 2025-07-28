class ApiRoutes {
    static base = `/api`
    
    static modelStructureRoute = {
        'client' : `/structure/clientDisplay`,
        'payment' : `/structure/paymentDisplay`
    }

    static authenticationRoutes = {
        'register' : `/authentication/register`,
        'login' : `/authentication/login`,
        'getRoles' : `/authentication/getRoles`
    }

    static clientRoute = {
        'create' : `/clients/create`,
        'update' : `/clients/update`,
        'delete' : `/clients/delete/{clientId}`,
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