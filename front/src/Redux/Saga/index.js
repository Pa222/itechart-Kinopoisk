import {all, fork} from 'redux-saga/effects';
import * as MovieSaga from './MovieSaga';
import * as UserSaga from './UserSaga'

export default function* rootSaga(){
    yield all([
        ...Object.values(MovieSaga),
        ...Object.values(UserSaga),
    ].map(fork));
}