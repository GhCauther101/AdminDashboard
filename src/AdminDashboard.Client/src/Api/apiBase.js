import axios from "axios";
import ApiRoutes from "./data/apiRoutes.js";

class ApiResolver {
    static apiInstance = null;

    static defaultHeadersSet = {
        "Accept": "aplication/json",
        "Content-Type": "application/json",
        "Access-Control-AllowOrigin": "*"
    }

    static resolveApi (url=ApiRoutes.base, headers=this.defaultHeadersSet) {
        this.apiInstance = axios.create({ baseURL: url, headers: headers, withCredentials: true});
        this.apiInstance.interceptors.request.use(
            (config) => {
                console.log(`[Request] ${JSON.stringify(config, null, 2)} ${config.url}`, config.data);
                return config;
            },
            (error) => {
                console.error('[Request Error]', error);
                return Promise.reject(error);
            }
        );
    
        this.apiInstance.interceptors.response.use(
            (response) => {
                console.log(`[Response] ${response.status} ${response.config.url}`, response);
                return response;
            },
            (error) => {
                if (error.response) {
                    console.error(`[Response Error] ${error.response.status} ${error.config.url}`, error.response.data);
                } else {
                    console.error('[Response Error]', error.message);
                }
                return Promise.reject(error);
            }
        );
    
        return this.apiInstance;
    }
}

export default ApiResolver;