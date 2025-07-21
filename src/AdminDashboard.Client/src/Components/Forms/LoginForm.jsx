import { useState } from "react";
import { FaUser, FaLock } from "react-icons/fa";
import  accountLogin from "../../Api/accountLogin.js";
import "./DefaultForm.css";

const LoginForm = () => {
    const [userName, setUsername] = useState('')
    const [userPassword, setPassword] = useState('')
    
    const handleSubmit = (e) => {
        accountLogin(userName, userPassword);
    }

    return (
        <div className="wrapper">
            <form onClick={(e) => handleSubmit(e)}>
                <h1>Login</h1>
                <div className="input-box">
                    <input type="text" placeholder="username" required value={userName} onChange={(e) => setUsername(e.target.value)}/>
                    <FaUser className="icon"/>
                </div>
                <div className="input-box">
                    <input type="password" placeholder="password" required value={userPassword} onChange={(e) => setPassword(e.target.value)}/>
                    <FaLock className="icon"/>
                </div>

                <button type="submit">Login</button>

                <div className="register-link">
                    <p> Don't have an account? <a href="/register">Register</a></p>
                </div>
            </form>
        </div>
    )
};

export default LoginForm;