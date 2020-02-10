import React from 'react';
import './App.css';
import { BrowserRouter } from 'react-router-dom';
// import Home from '../src/pages/home/Home';
import Shell from '../src/Shell';


function App() {
  return (
    <BrowserRouter>
    <div className="App">
      <Shell />
    </div>
    </BrowserRouter>
  );
}

export default App;
