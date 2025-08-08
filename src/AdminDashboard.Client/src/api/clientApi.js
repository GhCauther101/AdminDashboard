import ApiResolver from "./apiBase";
import ApiResult from "./data/apiResult.js";
import ApiRoutes from "./data/apiRoutes.js";

class ClientApi {
    getAll = async () => {
        var route = ApiRoutes.clientRoute.getAll;
        var result = new ApiResult();
        
        const api = ApiResolver.resolveApi();
        await api.get(route)
            .then(data => 
            {
                var status = data.status;
                var success = status === 200;
                var data = data.data;
                result.define(success, status, data);
            })
            .catch(er => 
            {
                var success = false;
                var status = er.request.status;
                var errorData = er.request.response;
                result.define(success, status, errorData);
            });
        return result;
    }

    getSingle = async (clientId) => {
        var route = ApiRoutes.clientRoute.getSingle;
        route = route.replace('{clientId}', clientId)
        var result = new ApiResult();
        
        const api = ApiResolver.resolveApi();
        await api.get(route)
            .then(data => 
            {
                var status = data.status;
                var success = status === 200;
                var data = data.data;
                result.define(success, status, data);
            })
            .catch(er => 
            {
                var success = false;
                var status = er.request.status;
                var errorData = er.request.response;
                result.define(success, status, errorData);
            });
        return result;
    }

    getVolumed = async (width) => {
        var route = ApiRoutes.clientRoute.getVolumed;
        route = route.replace('{width}', width)
        var result = new ApiResult();
        
        const api = ApiResolver.resolveApi();
        await api.get(route)
            .then(data => 
            {
                var status = data.status;
                var success = status === 200;
                var data = data.data;
                result.define(success, status, data);
            })
            .catch(er => 
            {
                var success = false;
                var status = er.request.status;
                var errorData = er.request.response;
                result.define(success, status, errorData);
            });
        return result;
    }

    updateClient = async (updateClient) => {        
        var route = ApiRoutes.accountRoutes.update;
        var result = new ApiResult();

        const api = ApiResolver.resolveApi();
        await api.put(route, updateClient)
            .then(data => 
            {
                var status = data.status;
                var success = status === 200;
                var data = data.data;
                result.define(success, status, data);
            })
            .catch(er => 
            {
                var success = false;
                var status = er.request.status;
                var errorData = er.request.response;
                result.define(success, status, errorData);
            });
        return result;
    }

    deleteClient = async (clientId) => {
        var route = ApiRoutes.accountRoutes.delete;
        var route = route.replace('{clientId}', clientId);
        var result = new ApiResult();

        const api = ApiResolver.resolveApi();
        await api.delete(route)
            .then(data => 
            {
                var status = data.status;
                var success = status === 204;
                var data = data.data;
                result.define(success, status, data);
            })
            .catch(er => 
            {
                var success = false;
                var status = er.request.status;
                var errorData = er.request.response;
                result.define(success, status, errorData);
            });
        return result;
    }
}

export default ClientApi;