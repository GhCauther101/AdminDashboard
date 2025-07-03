import React, { useEffect, useState } from "react";
import { FaUser, FaLock } from "react-icons/fa";
import { MdAlternateEmail } from "react-icons/md";
import accountRegister from "../../Api/authApi";
import "./DefaultForm.css";

const RegisterForm = () => {
    const [userName, setUsername] = useState()
    const [userEmail, setEmail] = useState()
    const [userPassword, setPassword] = useState()
    const [userRole, setRole] = useState()

    const handlSubmit = async (e) => {
        debugger
        await accountRegister(userName, userEmail, userPassword, userRole);
    }

    return (
        <div className="wrapper">
            <form >
                <h1>Register</h1>
                <div className="input-box">
                    <input type="text" placeholder="username" required value={userName} onChange={(e) => setUsername(e.target.value)} />
                    <FaUser className="icon"/>
                </div>
                <div className="input-box">
                    <input type="text" placeholder="email" required value={userEmail} onChange={(e) => setEmail(e.target.value)}/>
                    <MdAlternateEmail className="icon"/>
                </div>
                <div className="input-box">
                    <input type="password" placeholder="password" required value={userPassword} onChange={(e) => setPassword(e.target.value)}/>
                    <FaLock className="icon"/>
                </div>

                <div className="input-box">
                    <select value={userRole} onChange={(e) => setRole(e.target.value)}>
                        <option value="admin">Administrator</option>
                        <option value="manager">Manager</option>
                        <option value="user">User</option>
                    </select>
                </div>

                <button type="submit" onClick={(e) => handlSubmit(e)}>Register</button>

                <div className="register-link">
                    <p> Already have an account? <a href="/login">Login</a></p>
                </div>

                <div className="error-line">
                    <p></p>
                </div>
            </form>
        </div>
    )
};

export default RegisterForm;