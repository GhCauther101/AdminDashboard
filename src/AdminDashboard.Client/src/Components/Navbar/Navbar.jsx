import React, { useEffect, useState } from 'react';
import "./navbar.css"

const Navbar = () => {
  const [logged, setLoggedStatus] = useState(false);

  useEffect(() => {
    var status = sessionStorage.getItem('loggedIn');
    setLoggedStatus(status);

    const checkLoginStatus = () => {
      var loggedIn = sessionStorage.getItem('loggedIn');

      if (!loggedIn || loggedIn === 'false'){
        setLoggedStatus(false);
      } else {
        setLoggedStatus(true);
      }
    };

    window.addEventListener('storage', checkLoginStatus);
    window.dispatchEvent(new Event("storage"));
  }, [])

  return (
    <div>
        <nav className='navbar'>
            <div className='sections'>
                <div className='logo'>
                  <a href='/' className='site-title'>Admin Dashboard</a>
                </div>
                <div className='layoutSection'>
                  <a href="/clients">Clients</a>
                  <a href="/payments">Payments</a>
                  <a href="/currency">Currency</a>
                </div>
            </div>
            <div className='authSection'>
              {logged ? (
                  <>
                    <a href="/logout">Sign out</a>
                  </>
                ) : (
                  <>
                    <a href="/register">Register</a>
                    <a href="/login">Sign in</a>
                  </>
              )}
            </div>
        </nav>
    </div>
  );
};

export default Navbar;