import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import ClientApi from '../../../api/clientApi';
import PaymentApi from '../../../api/paymentApi';
import ServiceApi from '../../../api/serviceApi';

import './HomePage.css';

const HomePage = () => {
    const navigate = useNavigate();

    const [clientCount, setClientCount] = useState();
    const [paymentCount, setPaymentCount] = useState();
    const [totalBill, setTotalBill] = useState();
    const [averageBill, setAverageBill] = useState();
    const [recentPayments, setRecentPayments] = useState([]);
    const [topClients, setTopClients] = useState([]);

    function performItemCreation(route) {
        navigate(route, { state: null });
    }

    async function getSnap() {
        var serviceApi = new ServiceApi();
        var snapResult = await serviceApi.getSnap();
        var parsedResult = snapResult.parse();
    
        if (parsedResult.isSuccess) {
            var snap = parsedResult.data.entity;

            setClientCount(snap.clientCount ?? '-');
            setPaymentCount(snap.paymentCount ?? '-');
            setTotalBill(snap.totalBill ?? '-');
            setAverageBill(snap.averageBill ?? '-');
        }
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
        getSnap();
        getLastPayments();
        getVolumedCLients();
    }, []);

    return (<div className="pageContainer">
        <div className="counterContainer">
            <span>Clients: {clientCount ?? ''}</span>
            <span>Payments: {paymentCount ?? ''}</span>
            <span>Total bill: {totalBill ?? ''}</span>
            <span>Avg: {averageBill ?? ''}</span>
        </div>
        <div className="listContainer">
            <div className='listHeader'>
                <p>Recent payments:</p>
            </div>
            <div className="tableArea">
                <div className="entityTable">
                    <div class="row">
                        <p class="cell">#</p>
                        <p class="cell">Source</p>
                        <p class="cell">Destination</p>
                        <p class="cell">Bill</p>
                        <p class="cell">Process time</p>
                    </div>
                    {recentPayments.map((payment, i)=> {
                        return (<div className='row'>
                            <p>{i + 1}</p>
                            <p>{payment.source_client.user_name}</p>
                            <p>{payment.destination_client.user_name}</p>
                            <p>{payment.bill}</p>
                            <p>{payment.process_time}</p>
                        </div>)
                    })}
                </div>
            </div>
        </div>
        <div className="listContainer">
            <div className='listHeader'>
                <p>Top clients by payment volume:</p>
            </div>            
            <div className="tableArea">
                <div className="entityTable">
                    <div class="row">
                        <p class="cell">#</p>
                        <p class="cell">Client</p>
                    </div>
                    {topClients.map((client, i)=> {
                        return (<div className='row'>
                            <p>{i + 1}</p>
                            <p>{client.userName}</p>
                        </div>)
                    })}
                    {/* {recentPayments.map((payment, i)=> {
                        return (<div className='row'>
                            <p>{i + 1})</p>
                            <p>{payment.source_client.user_name}</p>
                            <p>{payment.destination_client.user_name}</p>
                            <p>{payment.bill}</p>
                            <p>{payment.process_time}</p>
                        </div>)
                    })} */}
                </div>
            </div>            
        </div>
        <div className="actionContainer">
            <button onClick={() => performItemCreation('/newClient')}>Add client</button>
            <button onClick={() => performItemCreation('/newPayment')}>Pay</button>
        </div>
    </div>);
}

export default HomePage;