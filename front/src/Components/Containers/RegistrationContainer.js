import React, {useState} from 'react';
import Registration from '../Views/Registration/Registration';

const RegistrationContainer = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [repeatPassword, setRepeatPassword] = useState('');

    const handleChange = (e) => {
        const name = e.target.name;
        const value = e.target.value;

        name === "email" && setEmail(value);
        name === "password" && setPassword(value);
        name === "repeatPassword" && setRepeatPassword(value);
    }

    const handleSubmit = () => {
        console.log(`${email}: ${password}===${repeatPassword}`);
    }

    const registrationProps = {
        email,
        password,
        repeatPassword,
        handleChange,
        handleSubmit,
    }

    return(
        <Registration {...registrationProps} />
    );
};

export default RegistrationContainer;