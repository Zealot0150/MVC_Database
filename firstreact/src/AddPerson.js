import React, { Component } from "react"
import { useState,useEffect } from "react"; 

export const AddPerson = (props) =>
{

    const [cities, setCities] = useState([]);

    useEffect(() => {
      fetch("/api/React/GetAllCities", {
        headers: {
          accepts: "application/json",
        },
      })
          .then((response) => response.json())
          .then((data) => setCities(data));
    }, []);
  
    const [name, setName] = useState(" ");
    const [city, setCity] = useState("Berlin");
    const [tele, setTele] = useState(" ");
    

    const makeAddRequest =  (data) => {
        const resp = fetch("/api/React/CreatePerson?name="+ name + "&tele=" + tele + "&city=" + city, 
        {
            method: "POST",
            headers: {
              accepts: "application/json",
            },
            body:JSON.stringify(data),
          })
              .then((response) => response.json());
              return resp;
    }
    


    const handleNameChange = event => {
        setName(event.target.value);
      };

      const handleCityChange = event => {
        setCity(event.target.value);
      };

      const handleTeleChange = event => {
        setTele(event.target.value);
      };


    function handleChange(event) {
        makeAddRequest("Empty, dont use body");
      }
    

        return (

    <div className="wrapper">
      <h1>Lägg till person</h1>
      <form name="newPersonForm" onSubmit={handleChange}>
      <fieldset>
         <label>
           <p>Namn</p>
           <input name="name" required type="text" onChange={handleNameChange} />
         </label>

         <label>
           <p>Telefon</p>
           <input required type="text" name="tele" onChange={handleTeleChange}/>
         </label>

         <label>
           <p>Stad</p>
           <select name="city" value={city} onChange={handleCityChange} >
               {
               cities.map((c) =>
                    <option  value={c.CityId}> {c.CityId} </option>
               )

               }
            </select>
         </label>
       </fieldset>
       <button  name="newPersonForm" type="submit" >Skapa</button>
      </form>
    </div>                        
        
        )
}

export default AddPerson;