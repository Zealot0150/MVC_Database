import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import MainNav from "./MainNav";
import reportWebVitals from './reportWebVitals';
import AddPerson from './AddPerson';
import { Route, BrowserRouter, Routes } from 'react-router-dom'
import PeopleList from './PeopleList';
import PersonDetail from './PersonDetail';


ReactDOM.render(
  
   <BrowserRouter>
    <MainNav/>


    <Routes>
        <Route path="addPerson/" element={<AddPerson />} />
        <Route path="PeopleList/" element={<PeopleList/>} />
        <Route path="PersonDetail/" element={<PersonDetail/>} />
        
    </Routes>
    

        <App />
    </BrowserRouter>,
    document.getElementById("root")
);



//ReactDOM.render(
//    <React.StrictMode>
//    <App />
//  </React.StrictMode>,
//  document.getElementById('root')
//);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
