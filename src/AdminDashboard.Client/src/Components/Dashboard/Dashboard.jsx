import React from "react";
import { useNavigate } from "react-router-dom";

import "./Dashboard.css";

const Dashboard = ({columns, rawData}) => {
    const navigate = useNavigate();

    function processRow(route, inputClientRow = null) {        
        navigate(route, { state: inputClientRow });
    };

    return (
        <div>
        <div className="clientCreateArea">
            <button className="tableServiceButton tableCreateButton" onClick={() => processRow("/clientCreate")}>Add</button>
        </div>
        <div className="tableWrapper">
            
            <table className="clientDashTable">
                <thead>
                    <tr>
                        {columns.map((column) => {
                            return <th key={column}>{column}</th>
                        })}
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {rawData.map(row => {
                    return (
                        <tr key={row.id} onDoubleClick={() => processRow("/clientView", row.clientItem)}>
                            <td className="cell">{row.clientItem.clientId}</td>
                            <td className="cell">{row.clientItem.name}</td>
                            <td className="cell">{row.clientItem.email}</td>
                            <td className="cell">{row.clientItem.date}</td>
                            <td className="cell">{row.clientItem.password}</td>

                            <td><button className="tableServiceButton tableEditButton" onClick={() => processRow("/clientEdit", row.clientItem)}>Edit</button>
                            <button className="tableServiceButton tableDeleteButton">Delete</button></td>
                        </tr>
                    )})}
                </tbody>
            </table>            
        </div>
        </div>
    );
};

export default Dashboard;