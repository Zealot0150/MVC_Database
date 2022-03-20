import { useState,useEffect } from "react";
import React from 'react';
import { useNavigate } from "react-router-dom";


export const PeopleList = (props) => {

    const navigate = useNavigate();
    var sort = 0;

    function details(x)
    {
        navigate('/PersonDetail', 
        {
            state:{Key:x.Id, Item:x}   
        });
    }

    function sorting()
    {
        if(sort == 1)
            sort = -1;
        else
            sort = 1;
        if(sort > 0)
            sortAscending();
        else
            sortDecending();

            alert(sort);
    }    
    
      function sortAscending() {
        var temp  = people;
        const sorted = temp.sort(function(left, right) {
            return left.Name.localeCompare(right.Name);
        })
        setPeople(sorted);
      }

      function sortDecending() {
        var temp  = people;   
        const sorted = temp.sort(function(left, right) {
            return right.Name.localeCompare(left.Name);
        })
        setPeople(sorted);
      }

    const [people, setPeople] = useState([]); 

    useEffect(() => 
    {
        fetch("/api/React/", {
        headers: {
            accepts: "application/json",
        },
        })
            .then((response) => response.json())
            .then((data) => setPeople(data));
    },[] 
    );
    
    
        return (            
            <div>
                <div>
                </div>
                <div>
                    <h2>  Lista på människor </h2>
                </div>
                <div>
                    <table>
                        <thead>
                            <tr>
                                <th>
                                    Id
                                </th>
                                <th>
                                    Namn
                                </th>
                                <th>
                                </th>                               
                            </tr>
                        </thead>
                        <tbody>
                        {
                        people.//sort((a,b)=> {return a.Name > b.Name}).                        
                        map((x) =>
                        <tr>
                            <th>
                                {x.Id}
                            </th>
                            <th>
                                {x.Name}
                            </th>
                            <th>
                                <button onClick={()=>details(x) }   >  Detaljer </button>
                            </th>
                        </tr>  
                        )
                        }
                        </tbody>                           
                    </table>
                </div>
                <button onClick={sorting}  >
                     Sortera
                </button>
            </div>
            );
    }



export default PeopleList;
