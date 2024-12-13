import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from "./Login";
import Companies from "./company/Companies";
import Orders from "./Orders";
import CleanCompany from "./CleanCompany";

const RouterComponent: React.FC = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/Companies" element={<Companies />} />
        <Route path="/Orders" element={<Orders />} />
        <Route path="/CleanCompanies" element={<CleanCompany />} />
      </Routes>
    </Router>
  );
};

export default RouterComponent;
