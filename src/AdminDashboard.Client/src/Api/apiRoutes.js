class ApiRoutes {
    static base = `/api`
    static isFullUrl = true

    static authenticationRoutes = {
        'register' : `${this.base}/authentication/register`,
        'login' : `${this.base}/authentication/login`,
        'getRoles' : `${this.base}/authentication/getRoles`
    }

    static clientRoute = {
        'create' : `${this.base}/clients/create`,
        'update' : `${this.base}/clients/update`,
        'delete' : `${this.base}/clients/delete/{clientId}`,
        'getAll' : `${this.base}/clients/getAll`,
        'getSingle' : `${this.base}/clients/getSingle/{clientId}`
    }

    static paymentRoute = {
        'create' : `${this.base}/payments/create`,
        'update' : `${this.base}/payments/update`,
        'delete' : `${this.base}/payments/delete/{paymentId}`,
        'getAll' : `${this.base}/payments/getAll`,
        'getSingle' : `${this.base}/payments/getSingle/{paymentId}`,
        'getSingle' : `${this.base}/payments/getlastRange`
    }
}

export default ApiRoutes;