import { UPDATE_MOVIE, FETCH_MOVIE_ASYNC, CLEAN_MOVIE } from "./ActionTypes"


export const updateMovie = (movie) => {
    return {
        type: UPDATE_MOVIE,
        movie,
    }
}

export const cleanMovie = () => {
    return {
        type: CLEAN_MOVIE,
    }
}

export const fetchMovieAsync = (id) => {
    return {
        type: FETCH_MOVIE_ASYNC,
        id,
    }
}