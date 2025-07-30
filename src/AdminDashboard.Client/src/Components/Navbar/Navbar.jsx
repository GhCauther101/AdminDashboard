import React from 'react';
import "./navbar.css"

const Navbar = () => {
  return (
    <div>
        <nav className='navbar'>
            <a href='/' className='site-title'>Admin Dashboard</a>
            <div className='sections'>
                <a href="/clients">Clients</a>
                <a href="/payments">Payments</a>
                <a href="/currency">Currency</a>
            </div>
        </nav>
    </div>
  );
};

export default Navbar;