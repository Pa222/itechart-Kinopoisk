import { put, takeLatest, call } from 'redux-saga/effects'
import { cleanMovie, updateMovie } from '../Actions';
import { FETCH_MOVIE_ASYNC } from '../ActionTypes';


export function* watchFetchMovie(){
    yield takeLatest(FETCH_MOVIE_ASYNC, fetchMovieAsync);
}

function* fetchMovieAsync(action){
    try{
        yield put(cleanMovie());
        const movie = yield call(() => {
            return fetch(`http://localhost:28880/api/Catalog/get/${action.id}`).then(res => res.json());
        })
        yield put(updateMovie(movie));
    } catch(e){
        console.log(e);
    }
}