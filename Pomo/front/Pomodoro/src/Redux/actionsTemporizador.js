import axios from "axios";
axios.defaults.baseURL = "https://localhost:44387/api/";

export const GET_TEMPORIZADOR = "GET_TEMPORIZADOR";

export const getTemporizador =()=>{
    return async function (dispatch){
try {
    const temporizadorData = await axios.get('Temporizador');
    const temporizador = temporizadorData.data;
    dispatch({type:GET_TEMPORIZADOR, payload: temporizador})
} catch (error) {
    alert("Get temporizador no cargado")
    console.error(error);
}
    }
}

export const startPolling = () => {
    return function (dispatch) { 
        setInterval(() => {
            dispatch(getTemporizador());
        }, 1000); // Polling cada 1 segundo
    };
};

export const startTemporizador = (payload)=>{
    return async function(){
        try {
            const temporizadorStart = await axios.post(`/Temporizador/start?minutes=${payload}`);
            alert(temporizadorStart.data)
            console.log(temporizadorStart)
            alert(payload + " startTemporizador")
            console.log(payload + " startTemporizador")

            return temporizadorStart

        } catch (error) {
            alert('Error al iniciar temporizador')
            console.error(error)
        }
    }
}

export const pauseTemporizador = ()=>{
    return async function (){
try {
    const temporizadorPause = await axios.post("Temporizador/pause");
    alert(temporizadorPause.data)
    return temporizadorPause

} catch (error) {
    alert("Error al pausar el temporizador")
    console.error(error)
}
    }
}
export const resetTemporizador = ()=>{
    return async function (){
try {
    const temporizadorReset = await axios.post("Temporizador/reset");
    alert(temporizadorReset.data)
    return temporizadorReset

} catch (error) {
    alert("Error al resetear el temporizador")
    console.error(error)
}
    }
}
