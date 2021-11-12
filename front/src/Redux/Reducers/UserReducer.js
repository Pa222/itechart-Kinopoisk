import { removeCookie } from "../../Utils/Cookies";
import { ADD_USER_CREDIT_CARD, CLEAN_USER, SET_USER, UPDATE_USER } from "../ActionTypes";

const defaultState = {
    authorized: false,
    user: {
        role: '',
        name: '',
        phoneNumber: '',
        gender: '',
        email: '',
        creditCards: [],
        avatar: 'https://res.cloudinary.com/pa2/image/upload/v1636535929/UserAvatars/user_fhguim.png',
    },
}

const UserReducer = (state = defaultState, action) => {
    switch(action.type){
        case SET_USER:{
            state.user = action.payload;
            state.authorized = true;
            break;
        }
        case UPDATE_USER:{
            break;
        }
        case CLEAN_USER:{
            state.user = defaultState.user;
            state.authorized = false;
            removeCookie("AuthToken");
            break;
        }
        case ADD_USER_CREDIT_CARD:{
            state.user.creditCards.push(action.payload);
            Object.assign({}, state.user);
            break;
        }
        default:
            break;
    }
    return Object.assign({}, state);
}

export default UserReducer;