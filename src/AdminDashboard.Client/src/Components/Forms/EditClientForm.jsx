import { useEffect, useState } from "react";
import { FaUser, FaLock, FaCalendar } from "react-icons/fa";
import { MdAlternateEmail } from "react-icons/md";
import { useLocation } from "react-router-dom";

import "./DefaultForm.css"

const EditClientForm = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const data = location.state;
    
    const [role, setRole] = useState('')
    const [errors, setErrors] = useState()

    
    const processErrors = (registerResult) => {
        var jsonErrors = JSON.parse(registerResult.data);
        setErrors(jsonErrors);
    }

    const moveNext = () => {
        setUsername('');
        setEmail('');
        setPassword('');
        setRole('');

        navigate(-1);
    }

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (role != '' )
            data['roles'] = [ role ];

        var clientApi = new ClientApi();
        var clientEditResult = await clientApi.edit(data);
        var editResult = clientEditResult.parse();

        if (!editResult.isSuccess) {
            processErrors(editResult);
        } 
        else {
            moveNext();
        }
    };

    return (
        <div className="wrapper">
            <form action="handleSubmit">
                <h1>Edit client</h1>
                <div className="input-box">
                    <input type="text" placeholder="username" required value={data.user_name} onChange={(e) => setUsername(e.target.value)} />
                    {errors?.username ? plateError(errors.username) : null}
                    <FaUser className="icon"/>
                </div>
                <div className="input-box">
                    <input type="text" placeholder="email" required value={data.email} onChange={(e) => setEmail(e.target.value)}/>
                    {errors?.email ? plateError(errors.email) : null}
                    <MdAlternateEmail className="icon"/>
                </div>
                <div className="input-box">
                    <input type="password" autoComplete="current-password" placeholder="new password" required onChange={(e) => setPassword(e.target.value)}/>
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

                <button onClick={handleSubmit}>Edit</button>

                <div className="error-line">
                    <p></p>
                </div>
            </form>
        </div>
    );
};

export default EditClientForm;