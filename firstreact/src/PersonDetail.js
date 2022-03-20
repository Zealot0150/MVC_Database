
import React, { Component } from "react";
import { useParams } from 'react-router-dom';
import {useLocation} from 'react-router-dom';
import { useNavigate } from "react-router-dom";


export const PersonDetail = (props) => {
    const location = useLocation();
    const navigate = useNavigate();

    
    function remove()
    {
        const resp = fetch("/api/React/DeletePerson?id="+location.state.Item.Id , 
        {
            method: "POST",
            headers: {
              accepts: "application/json",
            },
            body:JSON.stringify(location.state.Item),
          })
          
          navigate('/PeopleList'); 
    }

    return(
            
        <div> 

            <h1> {location.state.Item.Name}  </h1>
              
            <table>
                <thead>
                    <tr>
                        <th> Id</th>
                        <th>Namn</th>
                        <th>Stad</th>
                        <th>Land</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                    <th>
                       id
                    </th>
                    <th>
                        {location.state.Item.Name}
                    </th>
                    <th>
                    {   location.state.Item.CityId}
                    </th>
                    <th>
                    {location.state.Item.Country}
                    </th>
                    </tr>
                </tbody>
            </table>
            <button onClick={remove}>Ta bort</button>


        </div>
    )

}

export default PersonDetail;