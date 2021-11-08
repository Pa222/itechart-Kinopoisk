import { put, takeLatest, call } from 'redux-saga/effects'
import { cleanMovie, updateMovie } from '../Actions';
import { FETCH_MOVIE_ASYNC } from '../ActionTypes';
import KinopoiskApi from '../../Api/KinopoiskApi';


export function* watchFetchMovie(){
    yield takeLatest(FETCH_MOVIE_ASYNC, fetchMovieAsync);
}

function* fetchMovieAsync(action){
    try{
        yield put(cleanMovie());
        const movie = yield call(() => {
            return KinopoiskApi.getMoviesById(action.id);
        })
        yield put(updateMovie(movie));
    } catch(e){
        console.log(e);
    }
}