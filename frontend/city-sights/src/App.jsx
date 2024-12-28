import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import SightsSeaction from "./components/SightsSection";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<SightsSeaction></SightsSeaction>} />
      </Routes>
    </Router>
  );
}

export default App;
