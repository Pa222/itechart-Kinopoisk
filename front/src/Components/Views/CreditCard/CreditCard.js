import React from "react";
import PropTypes from 'prop-types';
import useStyles from "./styles";

const CreditCard = (props) => {
    const classes = useStyles();

    return (
        <div className={classes.container}>
            <p className={classes.container__info}>{props.number}</p>
            <p className={classes.container__info}>{props.expiration}</p>
        </div>
    );
}

CreditCard.propTypes = {
    number: PropTypes.string,
    expiration: PropTypes.string,
}

export default CreditCard;