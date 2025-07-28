import { useState } from "react";
import { FaUser, FaLock } from "react-icons/fa";
import { useNavigate } from "react-router-dom";
import AuthApi from "../../api/authApi.js";
import plateError from "./FormWrapper.jsx";

import "./DefaultForm.css";

const LoginForm = () => {
    const navigate = useNavigate();

    const [userName, setUsername] = useState('')
    const [userPassword, setPassword] = useState('')
    const [errors, setRegisterErrors] = useState()

    const processErrors = (loginResult) => {
        var jsonErrors = JSON.parse(loginResult.data);
        setRegisterErrors(jsonErrors);
    }

    const moveNext = () => {
        setUsername('');
        setPassword('');
        navigate('/clients');
    }

    const handleSubmit = async (e) => {
        e.preventDefault();

        var objInstance = { username: userName, password: userPassword };
        var authApi = new AuthApi();
        var apiResult = await authApi.login(objInstance);
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
                <h1>Login</h1>
                <div className="input-box">
                    <input type="text" placeholder="username" required value={userName} onChange={(e) => setUsername(e.target.value)}/>
                    {errors?.username ? plateError(errors.username) : null}
                    <FaUser className="icon"/>
                </div>
                <div className="input-box">
                    <input type="password" placeholder="password" required value={userPassword} onChange={(e) => setPassword(e.target.value)}/>
                    {errors?.password ? plateError(errors.password) : null}
                    <FaLock className="icon"/>
                </div>

                <div>
                    <button onClick={handleSubmit}>Login</button>
                    {errors?.general ? plateError(errors.general) : null}
                </div>
                <div className="register-link">
                    <p> Don't have an account? <a href="/register">Register</a></p>
                </div>
            </form>
        </div>
    )
};

export default LoginForm;