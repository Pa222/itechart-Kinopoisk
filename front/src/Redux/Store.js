import { applyMiddleware, combineReducers, createStore } from "redux";
import MovieReducer from "./Reducers/MovieReducer";
import UserReducer from "./Reducers/UserReducer";
import createSagaMiddleware from "redux-saga";
import rootSaga from "./Saga";

const sagaMiddleware = createSagaMiddleware();

const rootReducer = combineReducers({
    movieState: MovieReducer,
    userState: UserReducer,
});

const Store = createStore(rootReducer, applyMiddleware(sagaMiddleware));

sagaMiddleware.run(rootSaga);

export default Store;