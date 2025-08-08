import { useNavigate, useLocation} from "react-router-dom";
import { useEffect, useState } from "react";
import { IoIosArrowBack } from "react-icons/io";
import { FaUser } from "react-icons/fa";
import { LuHistory } from "react-icons/lu";
import { ImArrowRight } from "react-icons/im";
import { ImArrowLeft } from "react-icons/im";
import { MdEmail } from "react-icons/md";

import "../display.css";
import PaymentApi from "../../../api/paymentApi";

const ClientDisplay = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const clientData = location.state;

    const [clientId, setClientId] = useState(clientData.client_id);
    const [userName, setUserName] = useState(clientData.user_name);
    const [userEmail, setUserEmail] = useState(clientData.email);
    const [userPayment, setUserPayment] = useState([]);
    
    const moveBack = () => {
        navigate(-1);
    }

    const retrievePaymentHistory = async () => {
        var paymentApi = new PaymentApi();
        var apiResult = await paymentApi.getHistory(clientId);
        var historyResult = apiResult.parse();

        if (historyResult.isSuccess) {
            setUserPayment(historyResult.data)
        }
    }

    function setClientData() {
        if (clientData) {
            retrievePaymentHistory();
        }
    }

    const getPaymentIcon = (payment) => {{
        return (payment.source_client.client_id === clientId) ? <ImArrowRight/> : <ImArrowLeft/>;
    }}

    const getPaymentUserName = (payment) => {{
        return (payment.source_client.client_id === clientId) ? payment.destination_client.user_name : payment.source_client.user_name;
    }}

    useEffect(() => {
        setClientData();
    }, [])

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
            <div className="idBox">
                <p className="val">Id: {clientId}</p>                
            </div>
            <div className="inputBox">
                <div className="hdrPrgContainer">
                    <FaUser className="icon"/>
                    <p className="hdrPrg">Username:</p>
                </div>
                <p className="val">{userName}</p>                
            </div>
            <div className="inputBox">
                <div className="hdrPrgContainer">
                    <MdEmail className="icon"/>
                    <p className="hdrPrg">Email:</p>
                </div>
                <p className="val">{userEmail}</p>
            </div>
            <div className="paymentsContainer">
                <div className="hdrPrgContainer">
                    <LuHistory className="icon"/>
                    <p className="hdrPrg">Payments:</p>
                </div>
                <div className="paymentsList">
                {userPayment.map(payment => {
                    return (<div className="paymentRow">
                        <span className="paymentRowIcon">{getPaymentIcon(payment)}</span>
                        <span className="paymentRowUserName">{getPaymentUserName(payment)}</span>
                        <span className="paymentRowBill">{payment.bill}</span>
                    </div>);
                })}
                </div>
            </div>
        </div>
    </div>);
}

export default ClientDisplay;