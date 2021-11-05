import { CLEAN_MOVIE, UPDATE_MOVIE } from "./ActionTypes";

const cleanMovie = {
    id: 0,
    title: 'Empty',
    genreMovies: [],
    description: 'Empty',
    createYear: 'Empty',
    image: 'Empty',
}

const Reducer = (state, action) => {
    switch(action.type){
        case CLEAN_MOVIE:{
            state['movie'] = cleanMovie;
            break;
        }
        case UPDATE_MOVIE:{
            state['movie'] = action.movie;
            break;
        }
        default:
            break;
    }
    return Object.assign({}, state);
}

export default Reducer;