import { applyMiddleware, createStore } from "redux";
import MovieReducer from "./Reducers/MovieReducer";
import createSagaMiddleware from "redux-saga";
import rootSaga from "./Saga";

const sagaMiddleware = createSagaMiddleware();

const defaultState = {
    movie:{
        id: 0,
        title: '',
        genreMovies: [],
        description: '',
        createYear: '',
        image: '',
    },
}

const Store = createStore(MovieReducer, defaultState, applyMiddleware(sagaMiddleware));

sagaMiddleware.run(rootSaga);

export default Store;