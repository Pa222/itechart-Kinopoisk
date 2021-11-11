import React, { useState } from "react";
import AddCreditCard from "../Views/AddCreditCard/AddCreditCard";

const AddCredirCardContainer = () => {
    const [number, setNumber] = useState('');
    const [expiry, setExpiry] = useState('');
    const [cardHolderName, setCardHolderName] = useState('');
    const [cvc, setCvc] = useState('');
    const [focus, setFocus] = useState('');
    const [numberMaxLength, setNumberMaxLength] = useState(16);

    const handleFocus = (e) => {
        setFocus(e.target.name);
    }

    const handleChange = (e) => {
        const { name, value } = e.target;
        
        name === "number" && setNumber(value);
        name === "expiry" && setExpiry(value);
        name === "cardHolderName" && setCardHolderName(value);
        name === "cvc" && setCvc(value);
    }

    const validateNumberOnlyInput = (e) => isNaN(String.fromCharCode(e.keyCode || e.which)) && e.preventDefault();

    const validateTextOnlyInput = (e) => !isNaN(String.fromCharCode(e.keyCode || e.which)) && e.preventDefault();
    
    
    const addCardProps = {
        number,
        expiry,
        cardHolderName,
        cvc,
        focus,
        numberMaxLength,
        setNumberMaxLength,
        handleFocus,
        handleChange,
        validateNumberOnlyInput,
        validateTextOnlyInput,
    }

    return (
        <AddCreditCard {...addCardProps} />
    );
}

export default AddCredirCardContainer;