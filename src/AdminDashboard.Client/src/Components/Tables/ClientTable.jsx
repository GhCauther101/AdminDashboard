import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import ModelStructureApi from "../../api/modelStructureApi.js";
import ClientApi from "../../api/clientApi.js";
import displayDeletePopup from "../Popups/Popup.jsx";

import "./ClientTable.css";

const ClientTable = () => {
    const navigate = useNavigate();
    const [columns, setColumns] = useState();
    const [data, setData] = useState();
    const [clientStructureErrors, setClientStructureErrors] = useState();
    const [showDeletePopup, setShowDeletePopup] = useState(false);

    function displayColumns() {
        if (!columns)
            return null;
        
        columns
        return (<tr>{columns.map((column) => {return <th key={column}>{column}</th>})}</tr>)
    }

    function displayDeleteDialog (object) {
        const clientApi = new ClientApi();
        const action = clientApi.deleteClient(object)
        return displayDeletePopup(showDeletePopup, () => setShowDeletePopup(false), object, action);
    }

    function displayRaws() {
        return (data)? data.map(row => 
        {
            return (<tr key={row.id} onDoubleClick={() => processRow("/clientView", row.clientItem)}>
                <td className="cell">{row.user_name}</td>
                <td className="cell">{row.email}</td>
                
                <td>
                    <button className="tableServiceButton tableEditButton" onClick={() => processRow("/clientEdit", row)}>Edit</button>
                    <button className="tableServiceButton tableDeleteButton" onClick={() => displayDeletePopup}>Delete</button>
                </td>
            </tr>)
        }):null
    }

    function processRow(route, inputClientRow = null) {
        navigate(route, { state: inputClientRow });
    };

    useEffect(()=> {
        const retrieveStruct = async () => 
        {
            var modelStructureExplorer = new ModelStructureApi();
            var clientStructure = null;
            await modelStructureExplorer.getClientStructure()
                .then(resp => 
                {
                    var result = resp.parse();
                    if (result.isSuccess && result.status === 200) {
                        clientStructure = result.data;
                    } else if (!result.isSuccess) {
                        setClientStructureErrors(result.data);
                    }
                });
            setColumns(clientStructure);
            setColumns(prev => [...prev, 'actions']);
        }

        const retrieveClientsData = async () => {
            var clientApi = new ClientApi();
            var clientData = null;
            await clientApi.getAll()
                .then(resp => 
                {
                    var result = resp.parse();
                    if (result.isSuccess && result.status === 200) {
                        clientData = result.data;
                    } else if (!result.isSuccess) {
                        setClientStructureErrors(result.data);
                    }
                });
            setData(clientData);
        }

        retrieveStruct();
        retrieveClientsData();
    }, []);

    return (
        <div className="companentContainer">
            <div className="clientCreateArea">
                <a className="clientTableLabel">Available clients</a>
                <button className="tableServiceButton tableCreateButton" onClick={() => processRow("/clientCreate")}>Add</button>
            </div>
            <div className="tableWrapper">
                <table className="clientDashTable">
                    <thead>
                        {displayColumns()}
                    </thead>
                    <tbody>
                        {displayRaws()}
                    </tbody>
                </table>            
            </div>
        </div>
    );
};

export default ClientTable;