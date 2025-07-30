import { BrowserRouter, Routes, Route} from 'react-router-dom';
import ClientTable from './Components/Tables/ClientTable';
import LoginForm from './Components/Forms/LoginForm';
import RegisterForm from './Components/Forms/RegisterForm';
import CreateClientForm from './Components/Forms/CreateClientForm';
import EditClientForm from './Components/Forms/EditClientForm';
import Navbar from './Components/Navbar/Navbar';

import './App.css';

function App() {
  return (
    <div className='container'>
      <BrowserRouter>
          <Navbar/>
          <Routes>
            <Route path="/" element={null}>
              <Route path="clients" element={<ClientTable />}/>
              <Route path="clientEdit" element={<EditClientForm />} />
              <Route path="clientCreate" element={<CreateClientForm />} />
              <Route path="login" element={<LoginForm />} />
              <Route path="register" element={<RegisterForm />} />
            </Route>
          </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;