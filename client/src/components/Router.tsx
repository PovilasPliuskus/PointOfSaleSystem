import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from "./Login";
import Orders from "./order/Orders";
import Company from "./company/Company";
import FullOrder from "./fullOrder/FullOrder";
import Establishment from "./establishment/Establishment";
import EstablishmentProduct from "./establishmentProduct/EstablishmentProduct";
import EstablishmentService from "./establishmentService/EstablishmentService";
import CompanyProduct from "./companyProduct/CompanyProduct";
import CompanyService from "./companyService/CompanyService";
import Employee from "./employee/Employee";

const RouterComponent: React.FC = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/Companies" element={<Company />} />
        <Route path="/CompanyProducts" element={<CompanyProduct />} />
        <Route path="/CompanyServices" element={<CompanyService />} />
        <Route path="/Establishments" element={<Establishment />} />
        <Route
          path="/EstablishmentProducts"
          element={<EstablishmentProduct />}
        />
        <Route
          path="/EstablishmentServices"
          element={<EstablishmentService />}
        />
        <Route path="/Employees" element={<Employee />} />
        <Route path="/Orders" element={<Orders />} />
        <Route path="/FullOrders" element={<FullOrder />} />
      </Routes>
    </Router>
  );
};

export default RouterComponent;
