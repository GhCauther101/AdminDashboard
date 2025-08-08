import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import ClientApi from '../../../api/clientApi';
import PaymentApi from '../../../api/paymentApi';

import './HomePage.css';

const HomePage = () => {
    const navigate = useNavigate();

    const [recentPayments, setRecentPayments] = useState([]);
    const [topClients, setTopClients] = useState([]);

    function performItemCreation(route) {
        navigate(route, { state: null });
    }

    async function getLastPayments() {
        var paymentApi = new PaymentApi();
        var apiResult = await paymentApi.getLast(15);
        var parsedResult = apiResult.parse();

        if (parsedResult.isSuccess) {
            setRecentPayments(parsedResult.data);
        }
    }

    async function getVolumedCLients() {
        var clientApi = new ClientApi();
        var apiResult = await clientApi.getVolumed(15);
        var parsedResult = apiResult.parse();
        
        if (parsedResult.isSuccess) {
            setTopClients(parsedResult.data);
        }
    }
  
    useEffect(() => {
        getLastPayments()
        getVolumedCLients();
    }, []);

    return (<div className="pageContainer">
        <div className="counterContainer">
            <span>Clients: 12</span>
            <span>Payments: 12</span>
            <span>Total: 12</span>
            <span>Avg: 12</span>
        </div>
        <div className="listContainer">
            <div className='listHeader'>
                <p>Recent payments:</p>
            </div>
            {recentPayments.map((payment, i)=> {
                return (<div className='listItem'>
                    <p>{i + 1})</p>
                    <p>{payment.source_client.user_name}</p>
                    <p>{payment.destination_client.user_name}</p>
                    <p>{payment.bill}</p>
                    <p>{payment.process_time}</p>
                </div>)
            })}
        </div>
        <div className="listContainer">
            <div className='listHeader'>
                <p>Top clients by payment volume:</p>
            </div>
            {topClients.map((client, i)=> {
                return (<div className='listItem'>
                    <p>{i + 1})</p>
                    <p>{client.userName}</p>
                </div>)
            })}
        </div>
        <div className="actionContainer">  
            <button onClick={() => performItemCreation('/newClient')}>Add client</button>
            <button onClick={() => performItemCreation('/newPayment')}>Pay</button>
        </div>
    </div>);
}

export default HomePage;