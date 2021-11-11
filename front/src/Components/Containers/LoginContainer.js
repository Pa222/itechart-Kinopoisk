import React, {useState} from "react";
import { useHistory } from "react-router";
import { connect } from "react-redux";
import { addCookie } from "../../Utils/Cookies";
import { cleanUser, setUser } from '../../Redux/Actions';
import PropTypes from 'prop-types';
import KinopoiskApi from "../../Api/KinopoiskApi";
import Login from "../Views/Login/Login";

const LoginContainer = (props) => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const history = useHistory();

    const handleChange = (e) => {
        const { name, value } = e.target;
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
        addCookie("AuthToken", token);
        
        const user = await KinopoiskApi.getUser();
        if (user === null){
            setErrorMessage("Неверные логин или пароль");
            return;
        }
        
        props.updateUser(user);
        setErrorMessage("");
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

const mapDispatchToProps = (dispatch) => {
    return {
        cleanUser: () => dispatch(cleanUser()),
        updateUser: (user) => dispatch(setUser(user)),
    }
}

LoginContainer.propTypes = {
    cleanUser: PropTypes.func,
    updateUser: PropTypes.func,
}

export default connect(null, mapDispatchToProps)(LoginContainer);