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

    const [paymentId, setPaymentId] = useState(paymentData.payment_id);
    const [sourceName, setSourceName] = useState(paymentData.source_client.userName);
    const [destinationName, setDestinationName] = useState(paymentData.destination_client.userName);
    const [bill, setBill] = useState(paymentData.bill);
    
    const moveBack = () => {
        navigate(-1);
    }

    return (<div className="wrapper">
        <div className="headerBox">
            <div className="icon" onClick={moveBack}>
                <IoIosArrowBack />
            </div>
            <div className="title">
                <h1>Payment</h1>
            </div>
        </div>
        <div className="displayBox">
            <div className="idBox">
                <p className="val">Id: {paymentId}</p>                
            </div>
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