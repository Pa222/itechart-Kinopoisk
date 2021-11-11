import React, {useState} from 'react';
import KinopoiskApi from '../../Api/KinopoiskApi';
import Registration from '../Views/Registration/Registration';

const RegistrationContainer = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [repeatPassword, setRepeatPassword] = useState('');
    const [name, setName] = useState('');
    const [message, setMessage] = useState('');

    const handleChange = (e) => {
        const { name, value } = e.target;

        name === "name" && setName(value);
        name === "email" && setEmail(value);
        name === "password" && setPassword(value);
        name === "repeatPassword" && setRepeatPassword(value);
    }

    const handleSubmit = async () => {
        if (await KinopoiskApi.register({email, password, name})){
            setMessage("Вы успешно зарегистрировались. Перейдите на страницу авторизации для входа");
            return
        }
        setMessage("Регистрация не удалась. Пользователь с таким e-mail уже существует");
    }

    const registrationProps = {
        email,
        password,
        repeatPassword,
        name,
        message,
        handleChange,
        handleSubmit,
    }

    return(
        <Registration {...registrationProps} />
    );
};

export default RegistrationContainer;