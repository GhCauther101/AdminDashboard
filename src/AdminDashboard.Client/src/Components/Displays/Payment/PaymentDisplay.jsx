import { useNavigate, useLocation} from "react-router-dom";
import { useEffect, useState } from "react";
import { IoIosArrowBack } from "react-icons/io";
import { FaMoneyBillAlt } from "react-icons/fa";
import { FaUser } from "react-icons/fa";

import "../display.css";

const PaymentDisplay = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const paymentData = location.state;

    const [sourceName, setSourceName] = useState();
    const [destinationName, setDestinationName] = useState();
    const [bill, setBill] = useState();
    
    const moveBack = () => {
        navigate(-1);
    }

    useEffect(() => {
        //..implement autofill logic        
    })

    return (<div className="wrapper">
        <div className="headerBox">
            <div className="icon">
                <IoIosArrowBack />
            </div>
            <div className="title">
                <h1>Payment</h1>
            </div>
        </div>
        <div className="displayBox">
            <div className="inputBox">
                <div className="hdrPrgContainer">
                    <FaUser className="icon"/>
                    <p className="hdrPrg">Source client:</p>
                </div>
                <p className="val">{sourceName}</p>
                
            </div>
            <div className="inputBox">
                <div className="hdrPrgContainer">
                    <FaUser className="icon"/>
                    <p className="hdrPrg">Destination client:</p>
                </div>
                <p className="val">{destinationName}</p>
            </div>
            <div className="inputBox">
                <div className="hdrPrgContainer">
                    <FaMoneyBillAlt className="icon"/>
                    <p className="hdrPrg">Bill:</p>
                </div>
                <p className="val">{bill}</p>
            </div>
        </div>
    </div>);
}

export default PaymentDisplay;