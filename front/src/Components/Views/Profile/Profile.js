import React from "react";
import PropTypes from 'prop-types';
import useStyles from "./styles";

const Profile = (props) => {
    const classes = useStyles();

    return (
        <div className={classes.wrapper}>
            <div className={classes.wrapper__profileContainer}>
                <div className={classes.profileContainer__avatarContainer}>
                    <img className={classes.profileContainer__avatar} src={props.avatar} alt="Avatar"></img>
                    <input 
                        className={classes.profileContainer__editButton} 
                        type="button" 
                        value="Сохранить изменения"
                        onChange={props.handleChange}
                        onClick={props.saveChanges}
                    ></input>
                </div>
                <div className={classes.profileContainer__informationContainer}>
                    <div>
                        <label className={classes.profileContainer__inforamtionKey}>Имя</label>
                        <input 
                            className={classes.profileContainer__informationValue}
                            name="name"
                            type="text" 
                            value={props.name}
                            onChange={props.handleChange}
                        ></input>
                    </div>
                    <div>
                        <label className={classes.profileContainer__inforamtionKey}>Номер телефона</label>
                        <input 
                            className={classes.profileContainer__informationValue} 
                            name="phoneNumber"
                            type="tel" 
                            value={props.phoneNumber}
                            onChange={props.handleChange}
                        ></input>
                    </div>
                    <div>
                        <label className={classes.profileContainer__inforamtionKey}>Номер карты</label>
                        <input 
                            className={classes.profileContainer__informationValue} 
                            name="cardNumber"
                            type="tel" 
                            inputMode="numeric" 
                            pattern="[0-9\s]{13,19}" 
                            autoComplete="cc-number" 
                            maxLength="19" 
                            placeholder="xxxx xxxx xxxx xxxx"
                            value={props.cardNumber}
                            onChange={props.handleChange}
                        ></input>
                    </div>
                    <div>
                        <label className={classes.profileContainer__inforamtionKey}>Пол</label>
                        <select 
                            className={classes.profileContainer__informationValue}
                            name="gender"
                            value={props.gender}
                            onChange={props.handleChange}
                        >
                            <option value="Female">Female</option>
                            <option value="Male">Male</option>
                            <option value="Undefined">Undefined</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
    );
}

Profile.propTypes = {
    name: PropTypes.string,
    phoneNumber: PropTypes.string,
    cardNumber: PropTypes.string,
    gender: PropTypes.string,
    avatar: PropTypes.string,
    saveChanges: PropTypes.func,
    handleChange: PropTypes.func,
}

export default Profile;