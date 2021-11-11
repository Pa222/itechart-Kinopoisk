import React, {useState} from "react";
import { connect } from "react-redux";
import { updateUser } from "../../Redux/Actions";
import PropTypes from 'prop-types';
import Profile from "../Views/Profile/Profile";

const ProfileContainer = (props) => {
    const [name, setName] = useState(props.name);
    const [email, setEmail] = useState(props.email);
    const [phoneNumber, setPhoneNumber] = useState(props.phoneNumber);
    const [cardNumber, setCardNumber] = useState(props.cardNumber);
    const [gender, setGender] = useState(props.gender);
    const [avatar, setAvatar] = useState(props.avatar);

    const handleChange = (e) => {
        const name = e.target.name;
        const value = e.target.value;

        name === "name" && setName(value);
        name === "email" && setEmail(value);
        name === "phoneNumber" && setPhoneNumber(value);
        name === "cardNumber" && setCardNumber(value);
        name === "gender" && setGender(value);
        name === "avatar" && setAvatar(value);
    }

    const saveChanges = () => {
        props.updateUser({name, email, phoneNumber, cardNumber, gender, avatar})
    }

    const profileProps = {
        name,
        email,
        phoneNumber,
        cardNumber,
        gender,
        avatar,
        saveChanges,
        handleChange
    }

    return (
        <Profile {...profileProps} />
    );
}

const mapStateToProps = (state) => {
    return {
        name: state.userState.user.name,
        email: state.userState.user.email,
        phoneNumber: state.userState.user.phoneNumber,
        cardNumber: state.userState.user.cardNumber,
        gender: state.userState.user.gender,
        avatar: state.userState.user.avatar,
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        updateUser: (user) => dispatch(updateUser(user)),
    }
}

ProfileContainer.propTypes = {
    user: PropTypes.object,
    updateUser: PropTypes.func,
}

export default connect(mapStateToProps, mapDispatchToProps)(ProfileContainer);