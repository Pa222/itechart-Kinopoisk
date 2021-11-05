import { UPDATE_MOVIE } from "./ActionTypes";

const Reducer = (state, action) => {
    if (action.type === UPDATE_MOVIE){
        state['movie'] = action.movie;
    }
    return Object.assign({}, state);
}

export default Reducer;