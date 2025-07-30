import { useState } from "react";
import { FaUser, FaLock } from "react-icons/fa";
import { MdAlternateEmail } from "react-icons/md";
import { useNavigate } from "react-router-dom";
import AuthApi from "../../api/authApi.js";
import plateError from "./FormWrapper.jsx";

import "./DefaultForm.css"

const CreateClientForm = () => {
    const navigate = useNavigate();
    const [userName, setUsername] = useState('')
    const [userEmail, setEmail] = useState('')
    const [userPassword, setPassword] = useState('')
    const [userRole, setRole] = useState('')
    const [errors, setErrors] = useState()
    
    const processErrors = (registerResult) => {
        var jsonErrors = JSON.parse(registerResult.data);
        setErrors(jsonErrors);
    }

    const moveNext = () => {
        setUsername('');
        setEmail('');
        setPassword('');
        setRole('');

        navigate('/clients');
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        var objInstance = { name: userName, email: userEmail, password: userPassword, roles: [userRole] };
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
                <h1>Create client</h1>
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
                    <select value={userRole} onChange={(e) => setRole(e.target.value)}>
                        <option value="admin">Administrator</option>
                        <option value="manager">Manager</option>
                        <option value="user">User</option>
                    </select>
                    {errors?.role ? plateError(errors.role) : null}
                </div>

                <div className="formButtonArea">
                    <button onClick={moveNext}>Close</button>
                    <button onClick={handleSubmit}>Create</button>
                </div>
            </form>
        </div>
    );
};

export default CreateClientForm;