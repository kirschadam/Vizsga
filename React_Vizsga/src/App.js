import { BrowserRouter, NavLink, Route, Routes } from 'react-router-dom';
import './App.css';
import List from './pages/List';
import New from './pages/New';
import Update from './pages/Update';
import Delete from './pages/Delete';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <div id='nav'>
          <div className='navbar' style={{maxWidth : 200}}>
            <NavLink to='/' className=' btn btn-info'>List</NavLink>
            <NavLink to='/new' className=' btn btn-info'>New Category</NavLink>
          </div>
        </div>
        <Routes>
          <Route path='/' element={<List/>}/>
          <Route path='/new' element={<New/>}/>
          <Route path='/update/:id' element={<Update/>}/>
          <Route path='/delete/:id' element={<Delete/>}/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
