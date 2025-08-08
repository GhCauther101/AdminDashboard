import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './HomePage.css';

const HomePage = () => {
    const navigate = useNavigate();

    const [recentPayments, setRecentPayments] = useState([]);
    const [topClients, setTopClients] = useState([]);

    function performItemCreation(route) {
        navigate(route, { state: null });
    }

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
            {recentPayments.map(payment=> {

            })}
        </div>
        <div className="listContainer">
            <div className='listHeader'>
                <p>Top clients by payment volume:</p>
            </div>
            {topClients.map(client=> {

            })}
        </div>
        <div className="actionContainer">  
            <button onClick={() => performItemCreation('/newClient')}>Add client</button>
            <button onClick={() => performItemCreation('/newPayment')}>Pay</button>
        </div>
    </div>);
}

export default HomePage;