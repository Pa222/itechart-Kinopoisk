import { CLEAN_USER, UPDATE_USER } from "../ActionTypes";

const defaultState = {
    email: '',
    name: '',
    cardNumber: '',
    gender: '',
    image: 'https://res.cloudinary.com/pa2/image/upload/v1636535929/user_fhguim.png',
}

const UserReducer = (state = defaultState, action) => {
    switch(action.type){
        case UPDATE_USER:{
            state = action.payload;
            break;
        }
        case CLEAN_USER:{
            state = defaultState;
            break;
        }
        default:
            break;
    }
    return Object.assign({}, state);
}

export default UserReducer;