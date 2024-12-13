import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from "./Login";
import Companies from "./company/Companies";
import Orders from "./Orders";

const RouterComponent: React.FC = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/Companies" element={<Companies />} />
        <Route path="/Orders" element={<Orders />} />
      </Routes>
    </Router>
  );
};

export default RouterComponent;
