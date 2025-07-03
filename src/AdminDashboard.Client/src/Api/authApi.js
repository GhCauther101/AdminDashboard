import axios from "axios";

const req = (url, method, hdrs, data) => {
    try
    {
        fetch(url,
        {
            method: method,
            headers: hdrs,
            body: data
        });
    }
    catch(err) {
        console.log(err);
    }
}

const accountRegister = async (iName, iEmail, iPassword, iRole) => {
    const url = "https://localhost:7003/api/authentication/register";

    const headersSet = {
        'Accept': '*/*',
        'Content-Type': 'application/json'
    };

    const config = {
        headers: headersSet
    };

    const clientForRegistration = "{" + `"name": ` + `"${iName}", ` + `"email": ` + `"${iEmail}", ` + `"password": ` + `"${iPassword}", ` + `"roles": ` + "[" + `"${iRole}"` + "]" + "}"
        .replaceAll("\\", " ");
    
    console.log(url);    
    console.log(clientForRegistration);
    
    await axios.post(url, clientForRegistration, config)
}

export default accountRegister;