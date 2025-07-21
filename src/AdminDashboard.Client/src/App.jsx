import { BrowserRouter, Routes, Route} from 'react-router-dom'
import Dashboard from './Components/Dashboard/Dashboard'
import LoginForm from './Components/Forms/LoginForm'
import RegisterForm from './Components/Forms/RegisterForm'
import CreateClientForm from './Components/Forms/CreateClientForm'
import EditClientForm from './Components/Forms/EditClientForm'
import './App.css'

function App() {
  const theadData = ["Id", "Name", "Email", "Date", "Password"];
  const tbodyData = [
    {
      id: 1, 
      clientItem: {
        clientId: 1,
        name: "Kevin",
        email: "kevin@email.com",
        password: "abc"
      }
    }, 
    {
      id: 2, 
      clientItem: {
        clientId: 2,
        name: "John",
        email: "john@email.com",
        password: "abc"
      }
    },
    {
      id: 3, 
      clientItem: {
        clientId: 3,
        name: "Kevin",
        email: "kevin@email.com",
        password: "abc"
      }
    },
    {
      id: 4, 
      clientItem: {
        clientId: 4,
        name: "Kevin",
        email: "kevin@email.com",
        password: "abc"
      }
    }, 
    {
      id: 5, 
      clientItem: {
        clientId: 5,
        name: "John",
        email: "john@email.com",
        password: "abc"
      }
    },
    {
      id: 6, 
      clientItem: {
        clientId: 6,
        name: "Kevin",
        email: "kevin@email.com",
        password: "abc"
      }
    },
    {
      id: 7, 
      clientItem: {
        clientId: 7,
        name: "Kevin",
        email: "kevin@email.com",
        password: "abc"
      }
    }, 
    {
      id: 8, 
      clientItem: {
        clientId: 8,
        name: "John",
        email: "john@email.com",
        password: "abc"
      }
    },
    {
      id: 9, 
      clientItem: {
        clientId: 9,
        name: "Kevin",
        email: "kevin@email.com",
        password: "abc"
      }
    },
    {
      id: 10, 
      clientItem: {
        clientId: 10,
        name: "Kevin",
        email: "kevin@email.com",
        password: "abc"
      }
    }
  ];

  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={null}>
            <Route path="clients" element={<Dashboard columns={theadData} rawData={tbodyData}/>}/>
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
