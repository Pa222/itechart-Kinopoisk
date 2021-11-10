import React from "react";
import { connect } from "react-redux";
import PropTypes from 'prop-types';
import Profile from "../Views/Profile/Profile";

const ProfileContainer = (props) => {

    const handleChange = (e) => {
        console.log('changed');
    }

    const saveChanges = () => {
        console.log('saved');
    }

    const profileProps = {
        user: props.user,
        saveChanges,
        handleChange
    }
    
    return (
        <Profile {...profileProps} />
    );
}

const mapStateToProps = (state) => {
    return {
        user: state.userState.user,
    }
}

ProfileContainer.propTypes = {
    user: PropTypes.object,
}

export default connect(mapStateToProps, null)(ProfileContainer);