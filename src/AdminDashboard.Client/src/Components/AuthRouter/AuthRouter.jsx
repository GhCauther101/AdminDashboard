import { useLocation } from "react-router-dom";
import RegisterForm from "../Forms/Client/RegisterForm";

function AuthRouter( { children } ) {
    var token = localStorage.getItem("loggedIn");
    var location = useLocation();

    var route = location.pathname;
    debugger  
    if (!token) {
        localStorage.setItem('cachedPath', route);
        return <RegisterForm/>;
    }

    return children;
}

export default AuthRouter;