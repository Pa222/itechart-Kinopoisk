import { put, takeLatest, call } from "@redux-saga/core/effects";
import { updateMovie, addUserCreditCard } from "../Actions";
import { ADD_USER_CREDIT_CARD_ASYNC, UPDATE_USER_ASYNC } from "../ActionTypes";
import KinopoiskApi from "../../Api/KinopoiskApi";

export function* watchUpdateMovie(){
    yield takeLatest(UPDATE_USER_ASYNC, updateMovieAsync);
}

export function* watchAddUserCreditCard(){
    yield takeLatest(ADD_USER_CREDIT_CARD_ASYNC, addUserCreditCardAsync);
}

function* updateMovieAsync(action){
    try{
        yield put(updateMovie(action.payload));
    } catch(e){
        console.log(e);
    }
}

function* addUserCreditCardAsync(action){
    try{
        const card = yield call(() => {
            return KinopoiskApi.addCreditCard(action.payload);
        })
        if (card !== null)
            yield put(addUserCreditCard(card));
    } catch(e){
        console.log(e);
    }
}