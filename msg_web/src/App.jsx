import React, { useContext } from 'react';
import { useState } from 'react';
import './App.css'
import Login from './routes/Login'
import Home from './routes/Home';

import { BrowserRouter, Routes, Route, Link, Navigate } from 'react-router-dom';

function App() {
  const [log, setLog] = useState(false)

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login log = {log} setLog={setLog}/>} />
        <Route path="/Home" element={<Home/>}/>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
