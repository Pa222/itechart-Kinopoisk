import React from "react";
import Cards from 'react-credit-cards';
import PropTypes from 'prop-types';
import useStyles from "./styles";
import 'react-credit-cards/es/styles-compiled.css';

const AddCreditCard = (props) => {
    const classes = useStyles();

    return (
        <div className={classes.wrapper}>
            <div className={classes.container}>
                <div>
                    <Cards
                        cvc={props.cvc}
                        expiry={props.expiry}
                        focused={props.focus}
                        name={props.cardHolderName}
                        number={props.number}
                        callback={(info, isValid) => {
                            props.setNumberMaxLength(info.maxLength);
                        }}
                    />
                </div>
                <form>
                    <div className={classes.container__form}>
                        <input
                            type="tel"
                            name="number"
                            placeholder="Номер карты"
                            maxLength={props.numberMaxLength}
                            onKeyPress={e => props.validateNumberOnlyInput(e)}
                            value={props.number}
                            onChange={props.handleChange}
                            onFocus={props.handleFocus}
                        />
                        <input
                            type="text"
                            name="cardHolderName"
                            placeholder="Имя держателя карты"
                            maxLength="100"
                            onKeyPress={e => props.validateTextOnlyInput(e)}
                            value={props.cardHolderName}
                            onChange={props.handleChange}
                            onFocus={props.handleFocus}
                        />
                        <input
                            type="text"
                            name="expiry"
                            placeholder="MM/YY Expiry"
                            maxLength="4"
                            onKeyPress={e => props.validateNumberOnlyInput(e)}
                            value={props.expiry}
                            onChange={props.handleChange}
                            onFocus={props.handleFocus}
                        />
                        <input
                            type="tel"
                            name="cvc"
                            placeholder="cvc"
                            maxLength="3"
                            onKeyPress={e => props.validateNumberOnlyInput(e)}
                            value={props.cvc}
                            onChange={props.handleChange}
                            onFocus={props.handleFocus}
                        />
                    </div>
                </form>
            </div>
        </div>
    );
}

AddCreditCard.propTypes = {
    number: PropTypes.string,
    expiry: PropTypes.string,
    cardHolderName: PropTypes.string,
    cvc: PropTypes.string,
    focus: PropTypes.string,
    numberMaxLength: PropTypes.number,
    setNumberMaxLength: PropTypes.func,
    handleFocus: PropTypes.func,
    handleChange: PropTypes.func,
    validateNumberOnlyInput: PropTypes.func,
    validateTextOnlyInput: PropTypes.func,
}

export default AddCreditCard;