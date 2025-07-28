import ApiResult from "./data/apiResult.js";
import ApiResolver from "./apiBase.js";
import ApiRoutes from "./data/apiRoutes.js";

class ModelStructureApi {
    getClientStructure = async () => {
        var route = ApiRoutes.modelStructureRoute.client;
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

    getPaymentStructure = async () => {
        var route = ApiRoutes.modelStructureRoute.payment;
        var result = new ApiResult();
        
        const api = ApiResolver.apiInstance();
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
}

export default ModelStructureApi;