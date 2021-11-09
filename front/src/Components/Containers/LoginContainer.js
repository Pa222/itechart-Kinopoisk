import React, {useState} from "react";
import { useHistory } from "react-router";
import KinopoiskApi from "../../Api/KinopoiskApi";
import Login from "../Views/Login/Login";

const LoginContainer = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const history = useHistory();

    const handleChange = (e) => {
        const name = e.target.name;
        const value = e.target.value;
        name === "email" && setEmail(value);
        name === "password" && setPassword(value);
    }

    const handleSubmit = async () => {
        const response = await KinopoiskApi.auth(email, password);
        console.log({...response});
    }

    const goToRegisterPage = () => history.push("/register");

    const loginProps = {
        goToRegisterPage,
        handleChange,
        handleSubmit,
        email,
        password,
    }

    return (
        <Login {...loginProps} />
    );
};

export default LoginContainer;