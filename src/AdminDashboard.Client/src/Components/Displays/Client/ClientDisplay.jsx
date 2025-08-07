import { useNavigate, useLocation} from "react-router-dom";
import { useEffect, useState } from "react";
import { IoIosArrowBack } from "react-icons/io";
import { FaUser } from "react-icons/fa";

import "../display.css";

const ClientDisplay = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const clientData = location.state;

    const [userName, setUserName] = useState();
    const [userEmail, setUserEmail] = useState();
    
    const moveBack = () => {
        navigate(-1);
    }

    useEffect(() => {
        if (clientData !== null) {
            setUserName(clientData.user_name);
            setUserEmail(clientData.email);
        }        
    })

    return (<div className="wrapper">
        <div className="headerBox">
            <div className="icon" onClick={moveBack}>
                <IoIosArrowBack />
            </div>
            <div className="title">
                <h1>Client</h1>
            </div>
        </div>
        <div className="displayBox">
            <div className="inputBox">
                <div className="hdrPrgContainer">
                    <FaUser className="icon"/>
                    <p className="hdrPrg">Source client:</p>
                </div>
                <p className="val">{userName}</p>
                
            </div>
            <div className="inputBox">
                <div className="hdrPrgContainer">
                    <FaUser className="icon"/>
                    <p className="hdrPrg">Destination client:</p>
                </div>
                <p className="val">{userEmail}</p>
            </div>
        </div>
    </div>);
}

export default ClientDisplay;