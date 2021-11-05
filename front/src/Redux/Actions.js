import { UPDATE_MOVIE, FETCH_MOVIE_ASYNC } from "./ActionTypes"


export const updateMovie = (movie) => {
    return {
        type: UPDATE_MOVIE,
        movie,
    }
}

export const fetchMovieAsync = (id) => {
    return {
        type: FETCH_MOVIE_ASYNC,
        id,
    }
}