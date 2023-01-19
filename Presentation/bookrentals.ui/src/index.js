import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import App from './App';
import BookList from './BookList';
import TransactionList from './TransactionList';
import MemberList from './MemberList';

// Bootstrap CSS
import "bootstrap/dist/css/bootstrap.min.css";
// Bootstrap Bundle JS
import "bootstrap/dist/js/bootstrap.bundle.min";

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <nav className="navbar navbar-expand-lg bg-body-tertiary" style={{backgroundColor: '#afddfe'}}>
        <div className="container">
          <span className="navbar-brand mb-0 h1">Kütüphane</span>
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <div className="navbar-nav">
              <Link to="/" className="nav-link" aria-current="page" >Kitaplar</Link>
              <Link to="/transactions" className="nav-link">Kiralanan Kitaplar</Link>
              <Link to="/members" className="nav-link">Üyeler</Link>
            </div>
          </div>
        </div>
      </nav>
      <Routes>
          <Route path='/' element={<BookList />} />
          <Route path="transactions" element={<TransactionList />} />
          <Route path="members" element={<MemberList />} />
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
);
