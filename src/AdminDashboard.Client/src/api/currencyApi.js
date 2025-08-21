import ApiResolver from "./apiBase";
import ApiResult from "./data/apiResult.js";
import ApiRoutes from "./data/apiRoutes.js";

class CurrencyApi {
    getServiceStatus = async () => {
        var route = ApiRoutes.currencyRoute.getStatus;

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

    getCurrencyList = async (paymentId) => {
        var route = ApiRoutes.currencyRoute.getCurrencyList;

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

    getCurrencyRate = async (currencyCode) => {
        var route = ApiRoutes.currencyRoute.getCurrencyRate;
        route = route.replace('{currencyCode}', currencyCode);

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

    getPairRate = async (baseCode, targetCode) => {
        var route = ApiRoutes.currencyRoute.getPairRate;
        route = route.replace('{baseCode}', baseCode).replace('{targetCode}', targetCode);

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
}

export default CurrencyApi;