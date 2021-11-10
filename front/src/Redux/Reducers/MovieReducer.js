import { CLEAN_MOVIE, UPDATE_MOVIE } from "../ActionTypes";

const defaultState = {
    id: 0,
    title: 'Empty',
    genreMovies: [],
    description: 'Empty',
    createYear: 'Empty',
    image: 'Empty',
}

const MovieReducer = (state = defaultState, action) => {
    switch(action.type){
        case CLEAN_MOVIE:{
            state = defaultState;
            break;
        }
        case UPDATE_MOVIE:{
            state = action.payload;
            break;
        }
        default:
            break;
    }
    return Object.assign({}, state);
}

export default MovieReducer;