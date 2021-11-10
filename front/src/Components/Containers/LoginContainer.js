import React, {useState} from "react";
import { useHistory } from "react-router";
import { connect } from "react-redux";
import { addCookie } from "../../Utils/Cookies";
import { cleanUser, updateUser } from '../../Redux/Actions';
import PropTypes from 'prop-types';
import KinopoiskApi from "../../Api/KinopoiskApi";
import Login from "../Views/Login/Login";

const LoginContainer = (props) => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const history = useHistory();

    const handleChange = (e) => {
        const name = e.target.name;
        const value = e.target.value;
        name === "email" && setEmail(value);
        name === "password" && setPassword(value);
    }

    const handleSubmit = async () => {
        const token = await KinopoiskApi.auth(email, password);

        if (token === null){
            props.cleanUser();
            setErrorMessage("Неверные логин или пароль");
            return;
        }

        setErrorMessage("");
        addCookie("AuthToken", token);
        
        const user = await KinopoiskApi.getUser();
        props.updateUser(user);

        history.push("/");
    }

    const goToRegisterPage = () => history.push("/register");

    const loginProps = {
        goToRegisterPage,
        handleChange,
        handleSubmit,
        email,
        password,
        errorMessage,
    }

    return (
        <Login {...loginProps} />
    );
};

const mapStateToProps = (state) => {
    return {

    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        cleanUser: () => dispatch(cleanUser()),
        updateUser: (user) => dispatch(updateUser(user)),
    }
}

LoginContainer.propTypes = {
    cleanUser: PropTypes.func,
    updateUser: PropTypes.func,
}

export default connect(mapStateToProps, mapDispatchToProps)(LoginContainer);