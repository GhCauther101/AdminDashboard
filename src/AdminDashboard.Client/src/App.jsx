import { BrowserRouter, Routes, Route} from 'react-router-dom';
import Navbar from './Components/Navbar/Navbar';
import LoginForm from "./Components/Forms/Client/LoginForm.jsx";
import LogoutForm from './Components/Forms/Client/LogoutForm';
import RegisterForm from './Components/Forms/Client/RegisterForm';
import ClientTable from './Components/Tables/Client/ClientTable.jsx';
import ClientDisplay from './Components/Displays/Client/ClientDisplay';
import CreateClientForm from './Components/Forms/Client/CreateClientForm';
import EditClientForm from './Components/Forms/Client/EditClientForm';
import PaymentTable from './Components/Tables/Payment/PaymentTable.jsx';
import PaymentForm from './Components/Forms/Payment/PaymentForm';
import PaymentDisplay from './Components/Displays/Payment/PaymentDisplay';
import CurrencyTable from './Components/Tables/Currency/CurrencyTable.jsx';
import HomePage from './Components/Pages/home/HomePage.jsx';
import AuthRouter from './Components/AuthRouter/AuthRouter.jsx';
import PairCurrencyDisplay from './Components/Displays/Currency/PairCurrencyDisplay.jsx';

import './App.css';

function App() {
  return (
    <div className='container'>
      <BrowserRouter>
          <Navbar/>
          <Routes>
            <Route path="/" element={<AuthRouter><HomePage/></AuthRouter>} />
            <Route path="clients" element={<AuthRouter><ClientTable/></AuthRouter>} />
            <Route path="client" element={<AuthRouter><ClientDisplay/></AuthRouter>} />
            <Route path="clientEdit" element={<AuthRouter><EditClientForm/></AuthRouter>} />
            <Route path="newClient" element={<AuthRouter><CreateClientForm/></AuthRouter>} />
            <Route path="payments" element={<AuthRouter><PaymentTable/></AuthRouter>} />
            <Route path="payment" element={<AuthRouter><PaymentDisplay/></AuthRouter>} />
            <Route path="newPayment" element={<AuthRouter><PaymentForm/></AuthRouter>} />
            <Route path="currency" element={<AuthRouter><CurrencyTable/></AuthRouter>} />
            <Route path="currencyConvert" element={<AuthRouter><PairCurrencyDisplay/></AuthRouter>} />
            <Route path="logout" element={<LogoutForm/>} />
            <Route path="login" element={<LoginForm/>} />
            <Route path="register" element={<RegisterForm/>} />
          </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;