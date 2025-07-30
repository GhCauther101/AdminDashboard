import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import ModelStructureApi from "../../api/modelStructureApi.js";
import ClientApi from "../../api/clientApi.js";
import Popup from "../Popups/Popup.jsx";

import "./ClientTable.css";

const ClientTable = () => {
    const navigate = useNavigate();
    
    const [columns, setColumns] = useState([]);
    const [data, setData] = useState([]);
    const [currentClient, setCurrentClient] = useState(null);
    const [showDeletePopup, setShowDeletePopup] = useState(false);
    const [errors, setErrors] = useState();

    async function retrieveColumns() {
        var modelStructureExplorer = new ModelStructureApi();
        var clientColumns = null;
        await modelStructureExplorer.getClientStructure()
            .then(resp => 
            {
                var result = resp.parse();
                if (result.isSuccess && result.status === 200) {
                    clientColumns = result.data;
                    clientColumns.push('actions');
                } else if (!result.isSuccess) {
                    setErrors(result.data);
                }
            });

        setColumns(clientColumns);
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

        setData(clientData);
    }

    function displayColumns() {
        return (columns) ? (<tr>{columns.map((column) => {return <th key={column}>{column}</th>})}</tr>) : null
    }

    function displayRows() {
        return (data) ? data.map(row =>
        {
            return (<tr key={row.client_id} onDoubleClick={() => processRow("/clientView", row.clientItem)}>
                <td className="cell">{row.user_name}</td>
                <td className="cell">{row.email}</td>
                
                <td>
                    <button className="tableServiceButton tableEditButton" onClick={() => processRow("/clientEdit", row)}>Edit</button>
                    <button className="tableServiceButton tableDeleteButton" onClick={() => defineClient(row)}>Delete</button>
                </td>
            </tr>)
        }) : null
    }

    function refreshClientTable(clientId) {
        setData(prevData => prevData.filter(item => item.client_id !== clientId));
    }

    function defineClient(client) {
        setCurrentClient(client);
        setShowDeletePopup(true);
    }

    function processRow(route, inputClientRow = null) {
        navigate(route, { state: inputClientRow });
    };

    const deletePopup = () => {
        const clientApi = new ClientApi();
        const bannerObj = { title: 'Remove client: ', object: currentClient.user_name };
        const action = () => { clientApi.deleteClient(currentClient.client_id); refreshClientTable(currentClient.client_id); setShowDeletePopup(false); };
        const closeBtn = { onTrigger: () => setShowDeletePopup(false), header: "Close" };
        const actionBtn = { onTrigger: () => action(), header: "Delete" };
        return Popup(bannerObj, closeBtn, actionBtn);
    };

    useEffect(()=> {
        retrieveColumns();
        retrieveClientsData();
    }, []);

    return (
        <div>
            {showDeletePopup && deletePopup()}
            <div className="companentContainer">
                <header>
                    <div className="clientCreateArea">
                        <a className="clientTableLabel">Available clients</a>
                        <button className="tableServiceButton tableCreateButton" onClick={() => processRow("/clientCreate", currentClient)}>Add</button>
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
};

export default ClientTable;