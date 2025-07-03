import React from "react";
import { FaUser, FaLock } from "react-icons/fa";
import "./DefaultForm.css";

const LoginForm = () => {
    return (
        <div className="wrapper">
            <form action="">
                <h1>Login</h1>
                <div className="input-box">
                    <input type="text" placeholder="username" required/>
                    <FaUser className="icon"/>
                </div>
                <div className="input-box">
                    <input type="password" placeholder="password" required/>
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