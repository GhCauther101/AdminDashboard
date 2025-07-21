import axios from "axios";

const accountRegister = async (url, data, headers) => {
    const jsonString = JSON.stringify(data);
    
    const config = {
        headers: headers
    };

    debugger
    const resp = await axios.post(url, data, config);
    return resp;
};

export default accountRegister;