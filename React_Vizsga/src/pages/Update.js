import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

export default function Update() {
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
      method:'PUT',
      headers:{
        'content-type':'application/json'
      },
      body:JSON.stringify({
        id:id,
        kepek:e.target.elements.kepek.value,
        megnevezes:e.target.elements.megnevezes.value,
        leiras:e.target.elements.leiras.value
      })
    })
    .then(navigate('/'))
    .catch(console.log);
  }

  return (
    <div>
      <form onSubmit={Submit}>
        <h1>Update</h1>
        <input type="text" defaultValue={item != null? item.kepek : ""} name="kepek" style={{minWidth:300}}/><br/>
        <input type="text" defaultValue={item != null? item.megnevezes : ""} name="megnevezes" style={{minWidth:300}}/><br/>
        <input type="text" defaultValue={item != null? item.leiras : ""} name="leiras" style={{minWidth:400}}/><br/>
        <button type='submit'>Modify</button>
      </form>
    </div>
  )
}
