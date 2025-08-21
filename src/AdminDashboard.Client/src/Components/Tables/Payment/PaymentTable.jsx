import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import ModelStructureApi from "../../../api/modelStructureApi.js";
import PaymentApi from "../../../api/paymentApi.js";

import "./table.css"

const PaymentTable = () => {
    const navigate = useNavigate();
    
    const [columns, setColumns] = useState([]);
    const [data, setData] = useState([]);
    const [currentPayment, setCurrentPayment] = useState(null);
    const [showDeletePopup, setShowDeletePopup] = useState(false);
    const [errors, setErrors] = useState();

    async function retrieveColumns() {
        var modelStructureExplorer = new ModelStructureApi();
        var paymentColumns = null;
        await modelStructureExplorer.getPaymentStructure()
            .then(resp => 
            {
                var result = resp.parse();
                if (result.isSuccess && result.status === 200) {
                    paymentColumns = result.data;
                } else if (!result.isSuccess) {
                    setErrors(result.data);
                }
            });
        setColumns(paymentColumns);
    }

    async function retrievePaymentsData () {
        var clientApi = new PaymentApi();
        var paymentData = null;
        await clientApi.getAll()
            .then(resp => 
            {
                var result = resp.parse();
                if (result.isSuccess && result.status === 200) {
                    paymentData = result.data;
                } else if (!result.isSuccess) {
                    setErrors(result.data);
                }
            });
        
        setData(paymentData);
    }

    function displayColumns() {
        return (columns) ? (<tr>{columns.map((column) => {return <th key={column}>{column}</th>})}</tr>) : null
    }

    function displayRows() {
        return (data) ? data.map(row =>
        {
            return (<tr className="tableRow" key={row.payment_id} onDoubleClick={() => processRow("/payment", row)}>
                <td className="cell">{row.payment_id}</td>
                <td className="cell">{row.source_client.user_name}</td>
                <td className="cell">{row.destination_client.user_name}</td>
                <td className="cell">{row.bill}</td>
                <td className="cell">{row.process_time}</td>
            </tr>)
        }) : null
    }

    function processRow(route, inputRow = null) {
        navigate(route, { state: inputRow });
    }

    useEffect(()=> {
        retrieveColumns();
        retrievePaymentsData();
    }, [])

    return (
        <div>
            <div className="companentContainer">
                <header>
                    <div className="headerArea">
                        <a className="headerLabel">Available payments</a>
                        <button className="tableServiceButton tableCreateButton" onClick={() => processRow("/newPayment", currentPayment)}>Pay</button>
                    </div>
                </header>
                <div className="tableWrapper">
                    <table className="clientDashTable">
                        <thead>
                            {displayColumns()}
                        </thead>
                        <tbody>
                            {displayRows()}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    )
}

export default PaymentTable;