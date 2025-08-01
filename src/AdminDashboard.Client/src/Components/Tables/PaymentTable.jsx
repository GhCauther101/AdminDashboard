import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import ModelStructureApi from "../../api/modelStructureApi.js";

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
        paymentColumns = ["id", "sender", "reciever", "bill", "actions"]
        setColumns(paymentColumns);
    }

    async function retrievePaymentsData () {
    }

    function displayColumns() {
        return (columns) ? (<tr>{columns.map((column) => {return <th key={column}>{column}</th>})}</tr>) : null
    }

    function displayRows() {
    }

    function refreshTable(paymentId) {
    }

    function definePayment(payment) {
        setCurrentPayment(payment);
        setShowDeletePopup(true);
    }

    function processRow(route, inputRow = null) {
        navigate(route, { state: inputRow });
    };

    const deletePopup = () => {
        return null;
    };

    useEffect(()=> {
        retrieveColumns();
        retrievePaymentsData();
    }, []);

    return (
        <div>
            {showDeletePopup && deletePopup()}
            <div className="companentContainer">
                <header>
                    <div className="clientCreateArea">
                        <a className="clientTableLabel">Available clients</a>
                        <button className="tableServiceButton tableCreateButton" onClick={() => processRow("/clientCreate", currentPayment)}>Add</button>
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
    );
}

export default PaymentTable;