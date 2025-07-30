import ApiResolver from './apiBase.js';
import ApiRoutes from "./data/apiRoutes.js";
import ApiResult from "./data/apiResult.js";
import axios from 'axios';

class AuthApi {
    register = async (objInstance) => {
        var route = ApiRoutes.accountRoutes.register;
        var result = new ApiResult();
        
        const api = ApiResolver.resolveApi();
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
                var success = false;
                var status = er.request.status;
                var errorData = er.request.response;
                result.define(success, status, errorData);
            });
        return result;
    }

    login = async (objInstance) => {
        var route = ApiRoutes.accountRoutes.login;
        var result = new ApiResult();

        const api = ApiResolver.resolveApi();
        await api.post(route, objInstance)
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

export default AuthApi;