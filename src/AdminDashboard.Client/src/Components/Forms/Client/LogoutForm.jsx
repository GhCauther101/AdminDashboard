import { useState } from "react";
import { useNavigate } from "react-router-dom";
import AuthApi from "../../../api/authApi.js";
import plateError from "../FormWrapper.jsx";

import "../DefaultForm.css";

const LogoutForm = () => {
    const navigate = useNavigate();

    const [errors, setRegisterErrors] = useState()

    const processErrors = (loginResult) => {
        var jsonErrors = JSON.parse(loginResult.data);
        setRegisterErrors(jsonErrors);
    }

    const moveBack = () => {
        navigate(-1);
    }

    const moveNext = () => {
        localStorage.setItem('loggedIn', false);
        window.dispatchEvent(new Event("storage"));
        navigate('/login');
    }

    const handleSubmit = async (e) => {
        e.preventDefault();

        var authApi = new AuthApi();
        var apiResult = await authApi.logout();
        var loginResult = apiResult.parse();
        
        if (!loginResult.isSuccess) {
            processErrors(loginResult);
        }
        else {
            moveNext();
        }
    };

    return (
        <div className="wrapper">
            <form>
                <h1>LogOut</h1>
                <div className="content">
                    <p>Would yoou like tou log out ?</p>
                </div>
                <div className="formButtonArea">
                    <button onClick={moveBack}>Close</button>
                    <button onClick={handleSubmit}>Logout</button>
                    {errors?.general ? plateError(errors.general) : null}
                </div>
            </form>
        </div>
    )
};

export default LogoutForm;