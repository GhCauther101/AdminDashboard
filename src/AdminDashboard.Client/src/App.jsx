import { BrowserRouter, Routes, Route} from 'react-router-dom';
import Navbar from './Components/Navbar/Navbar';
import LoginForm from "./Components/Forms/Client/LoginForm.jsx";
import LogoutForm from './Components/Forms/Client/LogoutForm';
import RegisterForm from './Components/Forms/Client/RegisterForm';
import ClientTable from './Components/Tables/ClientTable';
import ClientDisplay from './Components/Displays/Client/ClientDisplay';
import CreateClientForm from './Components/Forms/Client/CreateClientForm';
import EditClientForm from './Components/Forms/Client/EditClientForm';
import PaymentTable from './Components/Tables/PaymentTable';
import PaymentForm from './Components/Forms/Payment/PaymentForm';
import PaymentDisplay from './Components/Displays/Payment/PaymentDisplay';
import HomePage from './Components/Pages/home/HomePage.jsx';
import './App.css';

function App() {
  return (
    <div className='container'>
      <BrowserRouter>
          <Navbar/>
          <Routes>
              <Route path="/" element={<HomePage/>} />
              <Route path="clients" element={<ClientTable/>} />
              <Route path="client" element={<ClientDisplay/>} />
              <Route path="clientEdit" element={<EditClientForm/>} />
              <Route path="newClient" element={<CreateClientForm/>} />
              <Route path="payments" element={<PaymentTable/>} />
              <Route path="payment" element={<PaymentDisplay/>} />
              <Route path="newPayment" element={<PaymentForm/>} />            
              <Route path="logout" element={<LogoutForm/>} />
              <Route path="login" element={<LoginForm/>} />
              <Route path="register" element={<RegisterForm/>} />
          </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;