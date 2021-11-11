import { removeCookie } from "../../Utils/Cookies";
import { CLEAN_USER, SET_USER, UPDATE_USER } from "../ActionTypes";

const defaultState = {
    authorized: false,
    user: {
        role: '',
        name: '',
        phoneNumber: '',
        gender: '',
        email: '',
        cardNumber: '',
        avatar: 'https://res.cloudinary.com/pa2/image/upload/v1636535929/user_fhguim.png',
    },
}

const cleanUser = {
    role: '',
    name: '',
    phoneNumber: '',
    gender: '',
    email: '',
    cardNumber: '',
    avatar: 'https://res.cloudinary.com/pa2/image/upload/v1636535929/user_fhguim.png',
}

const UserReducer = (state = defaultState, action) => {
    switch(action.type){
        case SET_USER:{
            state.user = action.payload;
            state.authorized = true;
            break;
        }
        case UPDATE_USER:{
            Object.assign(state.user, action.payload);
            break;
        }
        case CLEAN_USER:{
            state.user = cleanUser;
            state.authorized = false;
            removeCookie("AuthToken");
            break;
        }
        default:
            break;
    }
    return Object.assign({}, state);
}

export default UserReducer;