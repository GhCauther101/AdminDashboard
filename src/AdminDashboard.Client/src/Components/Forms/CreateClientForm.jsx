import { FaUser, FaLock } from "react-icons/fa";
import { MdAlternateEmail } from "react-icons/md";
import "./DefaultForm.css"

const CreateClientForm = () => {
    return (
        <div className="wrapper">
            <form action="">
                <h1>Create client</h1>
                <div className="input-box">
                    <input type="text" placeholder="username" required/>
                    <FaUser className="icon"/>
                </div>
                <div className="input-box">
                    <input type="text" placeholder="email" required/>
                    <MdAlternateEmail className="icon"/>
                </div>
                <div className="input-box">
                    <input type="password" placeholder="password" required/>
                    <FaLock className="icon"/>
                </div>

                <button type="submit">Create</button>

                <div className="error-line">
                    <p></p>
                </div>
            </form>
        </div>
    );
};

export default CreateClientForm;