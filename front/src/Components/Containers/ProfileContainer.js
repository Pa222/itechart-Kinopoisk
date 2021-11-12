import React, {useState} from "react";
import { connect } from "react-redux";
import { updateUser } from "../../Redux/Actions";
import PropTypes from 'prop-types';
import Profile from "../Views/Profile/Profile";

const ProfileContainer = (props) => {
    const [name, setName] = useState(props.name);
    const [phoneNumber, setPhoneNumber] = useState(props.phoneNumber);
    const [creditCards, setCreditCards] = useState(props.creditCards);
    const [gender, setGender] = useState(props.gender);
    const [avatar, setAvatar] = useState(props.avatar);
    const [showAddCreditCard, setShowAddCreditCard] = useState(false);

    const handleChange = (e) => {
        const name = e.target.name;
        const value = e.target.value;

        name === "name" && setName(value);
        name === "phoneNumber" && setPhoneNumber(value);
        name === "cardNumber" && setCreditCards(value);
        name === "gender" && setGender(value);
        name === "avatar" && setAvatar(value);
    }

    const saveChanges = () => {
        // props.updateUser({name, phoneNumber, creditCards, gender, avatar})
        console.log({name, phoneNumber, creditCards, gender, avatar});
    }

    const toggleAddCreditCardContainer = () => setShowAddCreditCard(!showAddCreditCard);

    const profileProps = {
        name,
        phoneNumber,
        creditCards,
        gender,
        avatar,
        showAddCreditCard,
        saveChanges,
        handleChange,
        toggleAddCreditCardContainer,
    }

    return (
        <Profile {...profileProps} />
    );
}

const mapStateToProps = (state) => {
    return {
        name: state.userState.user.name,
        phoneNumber: state.userState.user.phoneNumber,
        creditCards: state.userState.user.creditCards,
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
    name: PropTypes.string,
    phoneNumber: PropTypes.string,
    cardNumber: PropTypes.string,
    gender: PropTypes.string,
    avatar: PropTypes.string,
    updateUser: PropTypes.func,
}

export default connect(mapStateToProps, mapDispatchToProps)(ProfileContainer);