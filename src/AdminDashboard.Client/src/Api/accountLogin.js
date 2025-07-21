import axios from "axios";

const accountLogin = (iName, iPassword) => {
    const url = "https://localhost:7003/api/authentication/login";
    const clientObj = { username: iName, password: iPassword };
    const authToken = '';

    const headersSet = {
        'Accept': '*/*',
        'Content-Type': 'application/json'
    };

    const config = {
        headers: headersSet
    };
    
    axios.post(url, clientObj, config)
        .then(function (resp) 
        {
           debugger;
           if (resp.status === 200)
           {
                console.debug(resp.data);
                authToken = resp.data['Token'];
           }
        })
        .catch(function (er) 
        {
           qdebugger;
           console.log(er);
        });
};

export default accountLogin;