import { BrowserRouter, Routes, Route} from 'react-router-dom';
import ClientTable from './Components/Tables/ClientTable';
import LoginForm from './Components/Forms/Client/LoginForm';
import LogoutForm from './Components/Forms/Client/LogoutForm';
import RegisterForm from './Components/Forms/Client/RegisterForm';
import CreateClientForm from './Components/Forms/Client/CreateClientForm';
import EditClientForm from './Components/Forms/Client/EditClientForm';
import Navbar from './Components/Navbar/Navbar';
import PaymentTable from './Components/Tables/PaymentTable';
import PaymentForm from './Components/Forms/Payment/PaymentForm';
import PaymentDisplay from './Components/Displays/Payment/PaymentDisplay';

import './App.css';

function App() {
  return (
    <div className='container'>
      <BrowserRouter>
          <Navbar/>
          <Routes>
            <Route path="/" element={null}>
              <Route path="clients" element={<ClientTable />} />
              <Route path="clientEdit" element={<EditClientForm />} />
              <Route path="clientCreate" element={<CreateClientForm />} />
              <Route path="payments" element={<PaymentTable />} />
              <Route path="payment" element={<PaymentDisplay />} />
              <Route path="newPayment" element={<PaymentForm />} />
            
              <Route path="login" element={<LoginForm />} />
              <Route path="logout" element={<LogoutForm />} />
              <Route path="register" element={<RegisterForm />} />
            </Route>
          </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;