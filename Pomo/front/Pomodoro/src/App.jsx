import './App.css'
import Pomodoro from "../src/Componentes/Pomo/Pomo.jsx"
import { Routes, Route } from 'react-router-dom'
import Temporizador from './Componentes/Temporizador/Temporizador.jsx'
import Header from './Componentes/Header/Header.jsx'
function App() {


  return (
      <div>
        <Header/>
          <Routes>
              <Route path="/" element={<Pomodoro/>} />
              <Route path="/temporizador" element={<Temporizador/>}/>
          </Routes>
      </div>
  )
}

export default App
 