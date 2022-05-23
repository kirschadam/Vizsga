import React, { useEffect, useState } from 'react'
import { NavLink } from 'react-router-dom';

export default function List() {
  const [list, setList] = useState([]);

  useEffect(() =>{
    fetch('https://localhost:7082/api/kategoriak')
    .then((res) => res.json())
    .then((json) => setList(json))
    .catch(console.log);
  }, []);
  
  return (
    <div>
      <h1>Lista</h1>
      {list.map((item) => (
        <div className=' card' key={item.id}>
          <div className=' card-body'>
            <div><img src={list != null ? "images/" + item.kepek : "https://via.placeholder.com/600x400"} alt={item.kepek}/></div>
            <div>{list != null ? item.megnevezes : ""}</div>
            <div>{list != null ? item.leiras : ""}</div>
            <NavLink to={'/update/' + item.id} className=' btn btn-success'>Update</NavLink>
            <NavLink to={'/delete/' + item.id} className=' btn btn-danger'>Delete</NavLink>
          </div>
        </div>
      ))}
    </div>
  )
}
