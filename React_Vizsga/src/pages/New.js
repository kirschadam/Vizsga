import React from 'react'
import { useNavigate } from 'react-router-dom';

export default function New() {
  const navigate = useNavigate();

  function Submit(e){
    e.preventDefault();

    fetch('https://localhost:7082/api/ujkategoriak/', 
    {
      method:'POST',
      headers:{
        'content-type':'application/json'
      },
      body:JSON.stringify({
        id:0,
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
        <h1>New Category</h1>
        <input type="text" defaultValue="" name="kepek" style={{minWidth:300}}/><br/>
        <input type="text" defaultValue="" name="megnevezes" style={{minWidth:300}}/><br/>
        <input type="text" defaultValue="" name="leiras" style={{minWidth:400}}/><br/>
        <button type='submit'>Add</button>
      </form>
    </div>
  )
}
