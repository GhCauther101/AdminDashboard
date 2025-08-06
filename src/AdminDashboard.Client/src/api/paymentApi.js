import ApiResolver from "./apiBase";
import ApiResult from "./data/apiResult.js";
import ApiRoutes from "./data/apiRoutes.js";

class PaymentApi {
    getAll = async () => {
        var route = ApiRoutes.paymentRoute.getAll;
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

    getSingle = async (paymentId) => {
        var route = ApiRoutes.paymentRoute.getSingle;
        route = route.replace('{paymentId}', paymentId)
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

    pay = async (paymentInstace) => {
        var route = ApiRoutes.paymentRoute.create;
        var result = new ApiResult();
        
        const api = ApiResolver.resolveApi();
        await api.post(route, paymentInstace)
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

export default PaymentApi;