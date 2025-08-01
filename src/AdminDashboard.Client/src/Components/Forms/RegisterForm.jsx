import { useState } from "react";
import { FaUser, FaLock } from "react-icons/fa";
import { useNavigate } from "react-router-dom";
import { MdAlternateEmail } from "react-icons/md";
import AuthApi from "../../api/authApi.js";
import plateError from "./FormWrapper.jsx";

import "./DefaultForm.css";

const RegisterForm = () => {
    const navigate = useNavigate();

    const [userName, setUsername] = useState('')
    const [userEmail, setEmail] = useState('')
    const [userPassword, setPassword] = useState('')
    const [userRole, setRole] = useState('')
    const [errors, setRegisterErrors] = useState()
    
    const processErrors = (registerResult) => {
        var json = JSON.parse(registerResult.data);
        setRegisterErrors(json);
    }

    const moveNext = () => {
        setUsername('');
        setEmail('');
        setPassword('');
        setRole('');
        navigate('/login');
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        var objInstance = { username: userName, email: userEmail, password: userPassword, roles: [userRole] };
        var authApi = new AuthApi();
        var apiResult = await authApi.register(objInstance);
        var registerResult = apiResult.parse();

        if (!registerResult.isSuccess) {
            processErrors(registerResult);
        } 
        else {
            moveNext();
        }
    };
 
    return (
        <div className="wrapper">
            <form>
                <h1>Register</h1>
                <div className="input-box">
                    <input type="text" placeholder="username" required value={userName} onChange={(e) => setUsername(e.target.value)} />
                    {errors?.username ? plateError(errors.username) : null}
                    <FaUser className="icon"/>
                </div>
                <div className="input-box">
                    <input type="text" placeholder="email" required value={userEmail} onChange={(e) => setEmail(e.target.value)}/>
                    {errors?.email ? plateError(errors.email) : null}
                    <MdAlternateEmail className="icon"/>
                </div>
                <div className="input-box">
                    <input type="password" autoComplete="current-password" placeholder="password" required value={userPassword} onChange={(e) => setPassword(e.target.value)}/>
                    {errors?.password ? plateError(errors.password) : null}
                    <FaLock className="icon"/>
                </div>

                <div className="input-box">
                    <select value={userRole ?? ''} onChange={(e) => setRole(e.target.value)}>
                        <option value="admin">Administrator</option>
                        <option value="manager">Manager</option>
                        <option value="user">User</option>
                    </select>
                    {errors?.role ? plateError(errors.role) : null}
                </div>

                <button onClick={handleSubmit}>Register</button>
                
                <div className="register-link">
                    <p> Already have an account? <a href="/login">Login</a></p>
                </div>
            </form>
        </div>
    )
};

export default RegisterForm;