import { useEffect, useState } from "react";
import { FaUser, FaLock, FaCalendar } from "react-icons/fa";
import { MdAlternateEmail } from "react-icons/md";
import { useLocation } from "react-router-dom";
import "./DefaultForm.css"

const EditClientForm = () => {
    const location = useLocation();
    const data = location.state;

    const client = {
        username: (data["name"]) ? data["name"] : "username",
        email: (data["email"]) ? data["email"] : "email",
        password: (data["password"]) ? data["password"] : "password"
    };

    return (
        <div className="wrapper">
            <form action="">
                <h1>Edit client</h1>
                <div className="input-box">
                    <input type="text" placeholder={client.username} required/>
                    <FaUser className="icon"/>
                </div>
                <div className="input-box">
                    <input type="text" placeholder={client.email} required/>
                    <MdAlternateEmail className="icon"/>
                </div>
                <div className="input-box">
                    <input type="password" placeholder={client.password} required/>
                    <FaLock className="icon"/>
                </div>

                <button type="submit">Apply</button>

                <div className="error-line">
                    <p></p>
                </div>
            </form>
        </div>
    );
};

export default EditClientForm;