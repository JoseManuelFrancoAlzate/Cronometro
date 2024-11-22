import axios from "axios";
axios.defaults.baseURL = "https://localhost:44387/api/";

export const GET_NUMBER = "GET_NUMBER";


export const getNumber = () => {
    return async function (dispatch) {
        try {
            const cronometroData = await axios.get('Cronometros');
            const cronometro = cronometroData.data;
            dispatch({ type: GET_NUMBER, payload: cronometro });
        } catch (error) {
            alert("Get cronometro no cargado correctamente");
            console.error(error);
        }
    };
};

// Hacer polling cada segundo
export const startPolling = () => {
    return function (dispatch) { 
        setInterval(() => {
            dispatch(getNumber());
        }, 1000); // Polling cada 1 segundo
    };
};

export const startNumber = ()=>{
    return async function (){
try {
    const cronometroStart = await axios.post("Cronometros/start");
    alert(cronometroStart.data)
    return cronometroStart

} catch (error) {
    alert("Error al iniciar el cronometro")
    console.error(error)
}
    }
}

export const pauseNumber = ()=>{
    return async function (){
try {
    const cronometroPause = await axios.post("Cronometros/pause");
    alert(cronometroPause.data)
    return cronometroPause

} catch (error) {
    alert("Error al pausar el cronometro")
    console.error(error)
}
    }
}
export const resetNumber = ()=>{
    return async function (){
try {
    const cronometroReset = await axios.post("Cronometros/reset");
    alert(cronometroReset.data)
    return cronometroReset

} catch (error) {
    alert("Error al resetear el cronometro")
    console.error(error)
}
    }
}