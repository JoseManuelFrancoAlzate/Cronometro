import { createStore, applyMiddleware, compose } from "redux";
import { thunk } from "redux-thunk"; // Importa 'thunk' como una importación nombrada
import rootReducer from "./reducers"; // Ajusta esta ruta a la correcta si es necesario

const composeEnhancer = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const store = createStore(
    rootReducer,
    composeEnhancer(applyMiddleware(thunk))
);

export default store;
 