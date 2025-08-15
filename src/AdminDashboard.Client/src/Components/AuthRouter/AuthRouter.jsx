import { useLocation, useNavigate } from "react-router-dom";
import RegisterForm from "../Forms/Client/RegisterForm";

function AuthRouter( { children } ) {
    var loggedIn = sessionStorage.getItem('loggedIn');
    var location = useLocation()

    sessionStorage.setItem('locRoute', location.pathname);

    if (!loggedIn || loggedIn === 'false') {
        return <RegisterForm/>;
    }

    return children;    
}

export default AuthRouter;