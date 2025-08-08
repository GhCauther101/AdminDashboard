import { useState} from "react";
import { FaUser, FaLock, FaCalendar } from "react-icons/fa";
import { MdAlternateEmail } from "react-icons/md";
import { useLocation, useNavigate } from "react-router-dom";
import ClientApi from "../../../api/clientApi";

import "../DefaultForm.css"

const EditClientForm = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const data = location.state;

    const [username, setUsername] = useState(data.user_name);
    const [email, setEmail] = useState(data.email);
    const [password, setPassword] = useState(data.password);
    const [role, setRole] = useState(data.role);
    const [errors, setErrors] = useState(null);
    
    const processErrors = (registerResult) => {
        var jsonErrors = JSON.parse(registerResult.data);
        setErrors(jsonErrors);
    }

    const moveBack = () => {
        navigate(-1);
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
        
        var clientApi = new ClientApi();
        var updateCLientData = { client_id: data.client_id, user_name: username ?? '', email: email ?? '', password: password ?? '', role: role ?? '' };
        var clientEditResult = await clientApi.updateClient(updateCLientData);
        var editResult = clientEditResult.parse();

        if (!editResult.isSuccess) {
            processErrors(editResult);
        } 
        else {
            moveBack();
        }
    };

    return (
        <div className="wrapper">
            <form>
                <h1>Edit client</h1>
                <div className="input-box">
                    <input type="text" placeholder="username" value={username || ''} onChange={(e) => setUsername(e.target.value)} />
                    {errors?.user_name ? plateError(errors.user_name) : null}
                    <FaUser className="icon"/>
                </div>
                <div className="input-box">
                    <input type="text" placeholder="email" value={email || ''} onChange={(e) => setEmail(e.target.value)}/>
                    {errors?.email ? plateError(errors.email) : null}
                    <MdAlternateEmail className="icon"/>
                </div>
                <div className="input-box">
                    <input type="password" autoComplete="current-password" placeholder="new password" value={password || ''} onChange={(e) => setPassword(e.target.value)}/>
                    {errors?.password ? plateError(errors.password) : null}
                    <FaLock className="icon"/>
                </div>

                <div className="input-box">
                    <select value={role} onChange={(e) => setRole(e.target.value)}>
                        <option value="admin">Administrator</option>
                        <option value="manager">Manager</option>
                        <option value="user">User</option>
                    </select>
                    {errors?.role ? plateError(errors.role) : null}
                </div>

                <div className="formButtonArea">
                    <button onClick={moveBack}>Close</button>
                    <button onClick={handleSubmit}>Edit</button>
                </div>

                <div className="error-line">
                    <p></p>
                </div>
            </form>
        </div>
    );
};

export default EditClientForm;