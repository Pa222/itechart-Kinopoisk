import {all, fork} from 'redux-saga/effects';
import * as MovieSaga from './MovieSaga';

export default function* rootSaga(){
    yield all([
        ...Object.values(MovieSaga)
    ].map(fork));
}