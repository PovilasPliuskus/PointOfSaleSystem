import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from "./Login";
import Orders from "./order/Orders";
import Company from "./company/Company";
import FullOrder from "./fullOrder/FullOrder";
import Establishment from "./establishment/Establishment";

const RouterComponent: React.FC = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/Companies" element={<Company />} />
        <Route path="/Establishments" element={<Establishment />} />
        <Route path="/Orders" element={<Orders />} />
        <Route path="/FullOrders" element={<FullOrder />} />
      </Routes>
    </Router>
  );
};

export default RouterComponent;
