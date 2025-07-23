// import { apiInstance, defaultHeadersSet } from "./apiBase.js";
import ApiResolver from './apiBase.js'
import ApiRoutes from "./apiRoutes.js";
import ApiResult from "./apiResult.js";
import axios from 'axios';

class AuthApi {
    register = async (objInstance) => {
        var route = ApiRoutes.authenticationRoutes.register;
        var result = new ApiResult();
        
        const api = ApiResolver.apiInstance();
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
        var route = ApiRoutes.authenticationRoutes.login;
        var result = new ApiResult();

        const api = ApiResolver.resolveApi();
        await api.post(route, objInstance)
            .then(data => 
            {
                var status = data.status;
                var success = status === 200;
                var data = data.data;

                axios.defaults.headers.common.Authorization = `Bearer  ${data['token']}`;
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