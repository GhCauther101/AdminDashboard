import apiInstance from "./apiBase";
import ApiRoutes from "./apiRoutes";
import ApiResult from "./apiResult";

class AuthApi {
    register = async (objInstance) => {
        ApiRoutes.isFullUrl = true;
        var route = ApiRoutes.authenticationRoutes.register;
        var result = new ApiResult();

        const api = apiInstance();
        await api.post(route, objInstance)
            .then(data => 
            {
                var status = data.status;
                var success = status === 201;
                var data = data.data;
                result.define(success, status, data);
            })
            .catch(er => 
            {
                var status = er.request.status;
                var success = false;
                var errorData = er.request.response;
                result.define(success, status, errorData);
            });
        return result;
    }

    login = async (inputSet) => {
        ApiRoutes.isFullUrl = true;
        var route = ApiRoutes.authenticationRoutes.login;
        var result = false;
        const api = apiInstance();
        await api.post(route, objInstance)
            .then(data => { result = data.status === 201; })
            .catch(er => {throw er;});
        
        return result;
        
    }
}

export default AuthApi;