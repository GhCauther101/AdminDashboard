import axios from "axios"
import ApiRoutes from "./apiRoutes";

export const defaultHeadersSet = {
    "Accept": "aplication/json",
    "Content-Type": "application/json",
    "Access-Control-AllowOrigin": "*"
}

const apiInstance = (url=ApiRoutes.base, headers=defaultHeadersSet) => {
    var api = axios.create({ baseURL: url, headers: headers });
    // api.interceptors.request.use(
    //     (config) => {
    //         console.log(`[Request] ${JSON.stringify(config, null, 2)} ${config.url}`, config.data);
    //         return config;
    //     },
    //     (error) => {
    //         console.error('[Request Error]', error);
    //         return Promise.reject(error);
    //     }
    // );

    // api.interceptors.response.use(
    //     (response) => {
    //         console.log(`[Response] ${response.status} ${response.config.url}`, response);
    //         return response;
    //     },
    //     (error) => {
    //         if (error.response) {
    //             console.error(`[Response Error] ${error.response.status} ${error.config.url}`, error.response.data);
    //         } else {
    //             console.error('[Response Error]', error.message);
    //         }
    //         return Promise.reject(error);
    //     }
    // );

    return api;
}

export default apiInstance;