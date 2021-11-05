import { applyMiddleware, createStore } from "redux";
import Reducer from "./Reducer";
import createSagaMiddleware from "redux-saga";
import { watchFetchMovie } from "./Saga/MovieSaga";

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

const Store = createStore(Reducer, defaultState, applyMiddleware(sagaMiddleware));

sagaMiddleware.run(watchFetchMovie);

export default Store;