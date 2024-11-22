import styled from "./Temporizador.module.css";
import { useState, useEffect } from "react";
import { getTemporizador, pauseTemporizador, startTemporizador, startPolling, resetTemporizador} from "../../Redux/actionsTemporizador";
import Modal from '../Modal/Modal'
import { useSelector, useDispatch } from "react-redux";
const Temporizador= ()=>{
    
    const [showModal, setShowModal] = useState(false);
    const temporizador = useSelector(state => state.timeTemporizador)
    const [minutes, setMinutes] = useState({
        minutes: null
      })
  
    const dispatch = useDispatch();
 
      const handleChange = (e)=>{
  setMinutes({
    ...minutes,
    [e.target.name] : e.target.value
  })
      }

      const handleSubmit = async (e)=>{
        e.preventDefault();
        try {
            dispatch(startTemporizador(minutes.minutes))
            setShowModal(false)
        } catch (error) {
            alert("Error al iniciar cronometro");
            console.error("Error al iniciar cronometro", error);
        }}

        const handleReset = async ()=>{
            try {
                dispatch(resetTemporizador())
            } catch (error) {
                alert("error al reiniciar temporizador")
                console.error(error)
            }
        }

        
        const handleStart = ()=>{
    
        const duracion = temporizador.duracion.split(':')[1];
        console.log(duracion)
        alert("Handle Start")
        try {
        dispatch(startTemporizador(duracion))
        } catch (error) {
        alert("error al iniciar temporizador")
        console.error(error)
        }     
        }
        
        const handlePause = ()=>{
          try {
            dispatch(pauseTemporizador())
          } catch (error) {
            alert("Error al pausar temporizador")
            console.error(error)
          }
        }

    const handleOpenModal=()=>{
    setShowModal(true);
    }

    const handleCloseModal = ()=>{
        setShowModal(false)
    }

    useEffect(()=>{
        dispatch(getTemporizador());
       
        dispatch(startPolling());
        
        },[dispatch])

        console.log(temporizador)
return(
    <div className={styled.divTemporizador}>
        <h1 className={styled.title}>Temporizador</h1>
        <h1 className={styled.h1}>{temporizador.tiempoTranscurrido}</h1>
        <button onClick={handleOpenModal}  className={styled.buttonE}>Editar temporizador</button>
        <button onClick={handleReset} className={styled.buttonR}>Reiniciar</button>
        <button onClick={handleStart} className={styled.buttonI}>Iniciar</button>
        <button onClick={handlePause} className={styled.buttonP}>Pausar</button>
        <Modal show={showModal} handleClose={handleCloseModal}>
            <h2>Configurar la Duracion del Temporizador</h2>
            <form type="submit" onSubmit={handleSubmit}>
            <input name="minutes" onChange={handleChange} value={minutes.minutes}  type="number" placeholder="Minutos"/>
             <button className={styled.buttonI} > Iniciar</button>
            </form>
        </Modal>
    </div>
)
}


export default Temporizador
