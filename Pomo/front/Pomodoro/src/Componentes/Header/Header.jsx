import { useState } from "react";
import styled from "./Header.module.css"
import { useLocation } from "react-router-dom";
import { Link } from "react-router-dom";

const Header = () => {
    const [Pomodoro, setPomodoro] = useState(true)
    const location = useLocation();
    console.log(location)
    
    const booleanFunction = () =>{
        setPomodoro(!Pomodoro)
    }

    return (
      <header className={styled.header}>
        <Link to={Pomodoro ?  "Temporizador" : "/"} >
        <button onClick={booleanFunction} className={styled.h1}>
         {
       Pomodoro ?  "Temporizador" :"Cronometro" 
         }
        </button>
        </Link>
      </header>
    );
  };
  
  export default Header;
  