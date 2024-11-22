import styled from "../Pomo/Pomo.Module.css"
import {useDispatch, useSelector} from "react-redux"
import { getNumber, startNumber, pauseNumber,resetNumber, startPolling} from "../../Redux/actions"
import { useEffect } from "react"

const Pomodoro = () => {
    
    const cronometro = useSelector(state => state.time)

    const dispatch = useDispatch()

    const handleStart = async ()=>{
        try {
            dispatch(startNumber())
        } catch (error) {
            alert("error al iniciar cronometro")
            console.error(error)
        }
    }
    const handlePause = async ()=>{
        try {
            dispatch(pauseNumber())
        } catch (error) {
            alert("error al iniciar cronometro")
            console.error(error)
        }
    }
    const handleReset = async ()=>{
        try {
            dispatch(resetNumber())
        } catch (error) {
            alert("error al iniciar cronometro")
            console.error(error)
        }
    }
    useEffect(()=>{
    dispatch(getNumber())
    dispatch(startPolling()); // Iniciar el polling para actualizaciones en vivo
    },[dispatch])
    
    console.log(cronometro)
    return (
        <div className={styled.divPomodoro}>
            <h1 className={styled.saludo} >Cronometro</h1>
            <div>
                <h1 className={styled.h1}>{cronometro.tiempoTranscurrido}</h1>
                <form >
                <button onClick={handleStart}>Start</button>
                <button onClick={handlePause}>Pause</button>
                <button onClick={handleReset}>Resset</button>
                </form>
            </div> 
        </div>
    )
}


export default Pomodoro;