import React from "react";
import PropTypes from 'prop-types';
import CreditCard from "../Views/CreditCard/CreditCard";

const CreditCardContainer = (props) => {
    const creditCardProps = {
        number: props.number,
        expiration: props.expiration,
        image: props.image,
    }
    console.log({...props});

    return (
        <CreditCard {...creditCardProps} />
    );
}

CreditCardContainer.propTypes = {
    number: PropTypes.string,
    expiration: PropTypes.string,
    image: PropTypes.string,
}

export default CreditCardContainer;