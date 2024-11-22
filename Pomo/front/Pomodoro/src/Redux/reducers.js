import { GET_NUMBER } from "./actions";
import { GET_TEMPORIZADOR } from "./actionsTemporizador";
const initialState={
time: [],
timeTemporizador: []
}

const rootReducer= (state=initialState, action)=>{
    switch(action.type){
        case GET_NUMBER:
            return{
                ...state,
                time: action.payload
            }
            case GET_TEMPORIZADOR:
                return{
                    ...state,
                    timeTemporizador: action.payload
                }
default:
    return{...state};
    }
}

export default rootReducer