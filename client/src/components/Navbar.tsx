import React from "react";

const Navbar: React.FC = () => {
  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light">
      <div className="container-fluid">
        <a className="navbar-brand" href="/MainPage">
          Point Of Sale
        </a>
        <button
          className="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarNav"
          aria-controls="navbarNav"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav">
            <li className="nav-item">
              <a className="nav-link" href="/Companies">
                Companies
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/CompanyProducts">
                Company Products
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/CompanyServices">
                Company Services
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/Establishments">
                Establishments
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/Employees">
                Employees
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/EstablishmentProducts">
                Establishment Products
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/EstablishmentServices">
                Establishment Services
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/Orders">
                Orders
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/FullOrders">
                Full Orders
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/Taxes">
                Taxes
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="/GiftCards">
                Gift Cards
              </a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
