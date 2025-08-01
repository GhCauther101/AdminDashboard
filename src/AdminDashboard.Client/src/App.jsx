import { BrowserRouter, Routes, Route} from 'react-router-dom';
import ClientTable from './Components/Tables/ClientTable';
import LoginForm from './Components/Forms/Client/LoginForm';
import RegisterForm from './Components/Forms/Client/RegisterForm';
import CreateClientForm from './Components/Forms/Client/CreateClientForm';
import EditClientForm from './Components/Forms/Client/EditClientForm';
import Navbar from './Components/Navbar/Navbar';

import './App.css';
import { useState } from 'react';
import PaymentTable from './Components/Tables/PaymentTable';

function App() {

  {
    const cookies = document.cookie.split(';').map(cookie => console.log(cookie));    
  }

  return (
    <div className='container'>
      <BrowserRouter>
          <Navbar/>
          <Routes>
            <Route path="/" element={null}>
              <Route path="clients" element={<ClientTable />}/>
              <Route path="clientEdit" element={<EditClientForm />} />
              <Route path="clientCreate" element={<CreateClientForm />} />
              <Route path="payments" element={<PaymentTable />}/>
            
              <Route path="login" element={<LoginForm />} />
              <Route path="register" element={<RegisterForm />} />
            </Route>
          </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;