import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { FaMoneyBillAlt } from "react-icons/fa";
import { FaUser } from "react-icons/fa";
import ClientApi from "../../../api/clientApi";
import PaymentApi from "../../../api/paymentApi";

import '../DefaultForm.css'

const PaymentForm = () => {
    const navigate = useNavigate();

    const [clientList, setClientList] = useState([]);
    const [sender, setSender] = useState();
    const [reciever, setReciever] = useState();    
    const [sourceId, setSourceId] = useState();
    const [destinationId, setDestinationId] = useState();
    const [bill, setBill] = useState();
    const [date, setDate] = useState();
    const [errors, setErrors] = useState();

    const processErrors = (registerResult) => {
        var jsonErrors = JSON.parse(registerResult.data);
        setErrors(jsonErrors);
    }

    const moveBack = () => {
        setSourceId('');
        setDestinationId('');
        setBill('');
        setDate('');
        setErrors('');
        navigate(-1);
    }

    async function retrieveClientsData () {
        var clientApi = new ClientApi();
        var clientData = null;
        await clientApi.getAll()
            .then(resp => 
            {
                var result = resp.parse();
                if (result.isSuccess && result.status === 200) {
                    clientData = result.data;
                } else if (!result.isSuccess) {
                    setErrors(result.data);
                }
            });

        setClientList(clientData);
    }

    const handleSubmit = async (e) => {
        e.preventDefault();                
        var senderObj = clientList.find(client => client.user_name === sender);
        var recieverObj = clientList.find(client => client.user_name === reciever);
        
        const dateObj = new Date();
        var currentDateTime = dateObj.toUTCString();
        
        var objInstance = 
        { 
            sourceClientId: senderObj.client_id,
            destinationClientId: recieverObj.client_id,
            bill: bill,
            processtime: currentDateTime
        };

        var paymentApi = new PaymentApi();
        var apiResult = await paymentApi.pay(objInstance);
        var paymentResult = apiResult.parse();

        if (!paymentResult.isSuccess) {
            processErrors(paymentResult);
        } else {
            moveBack();
        }
    };

    useEffect(() => {
        retrieveClientsData();
    }, []);

    return (
        <div className="wrapper">
            <form>
                <h1>New payment</h1>
                <div className="input-box">
                    <input type="text" placeholder="sender" list="sourceClients" value={sourceId} required onChange={e => setSender(e.target.value)}/>
                    <datalist id="sourceClients">
                    {clientList.map(client => {
                        return (<option value={client.user_name}/>)
                    })}
                    </datalist>
                    <FaUser className="icon"/>
                </div>
                <div className="input-box">
                    <input type="text" placeholder="reciever" list="sourceClients" value={destinationId} onChange={e => setReciever(e.target.value)} required/>
                    <datalist id="sourceClients">
                    {clientList.map(client => {
                            return (<option value={client.user_name}/>)
                    })}
                    </datalist>
                    <FaUser className="icon"/>
                </div>
                <div className="input-box">
                    <input type="text" placeholder="bill" required value={bill} onChange={e => setBill(e.target.value)}/>
                    <FaMoneyBillAlt className="icon"/>
                </div>

                <div className="formButtonArea">
                    <button onClick={moveBack}>Close</button>
                    <button onClick={handleSubmit}>Pay</button>
                </div>
            </form>
        </div>
    );
}

export default PaymentForm;