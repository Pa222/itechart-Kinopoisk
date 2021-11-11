import { put, takeLatest } from "@redux-saga/core/effects";
import { updateMovie } from "../Actions";
import { UPDATE_USER_ASYNC } from "../ActionTypes";

export function* watchUpdateMovie(){
    yield takeLatest(UPDATE_USER_ASYNC, updateMovieAsync);
}

function* updateMovieAsync(action){
    try{
        yield put(updateMovie(action.payload));
    } catch(e){
        console.log(e);
    }
}