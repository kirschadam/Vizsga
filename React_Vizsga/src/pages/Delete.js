import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

export default function Delete() {
  const {id} = useParams();
  const [item, setItem] = useState();
  const navigate = useNavigate();
  
  useEffect(() => {
    fetch('https://localhost:7082/api/kategoriak/' + id)
    .then((res) => res.json())
    .then((json) => setItem(json))
    .catch(console.log);
  }, []);

  function Submit(e){
    e.preventDefault();

    fetch('https://localhost:7082/api/kategoriak/' + id, 
    {
      method:'DELETE',
      headers:{
        'content-type':'application/json'
      },
      body:JSON.stringify({
        id:id
      })
    })
    .then(navigate('/'))
    .catch(console.log);
  }
  
  return (
    <div>
      <form onSubmit={Submit}>
      <h1>Delete</h1>
      <p>{'Biztos benne hogy törölni szeretné a ' + (item != null ? item.megnevezes : "") + " elemet?"}</p><br/>
      <button type='submit'>Remove</button>
    </form>
    </div>
  )
}
