import React from "react";
import PropTypes from 'prop-types';
import CreditCard from "../Views/CreditCard/CreditCard";

const CreditCardContainer = (props) => {
    const creditCardProps = {
        number: props.number,
        expiration: props.expiration,
    }

    return (
        <CreditCard {...creditCardProps} />
    );
}

CreditCardContainer.propTypes = {
    number: PropTypes.string,
    expiration: PropTypes.string,
}

export default CreditCardContainer;