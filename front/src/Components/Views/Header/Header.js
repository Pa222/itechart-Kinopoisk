import React from "react";
import PropTypes from 'prop-types';
import useStyles from "./styles";

const Header = (props) => {
    const classes = useStyles();

    return (
        <header className={classes.header}>
            <div className={classes.header__content}>
                <div className={classes.header__title} onClick={props.goToMainPage}>
                    <p>КиноПоиск</p>
                </div>
                <div className={classes.header__searchBoxContainer}>
                    <input className={classes.header__searchBox} type="text" placeholder="Поиск"></input>
                    <img className={classes.header__searchButton} src="./search.png" alt="Поиск"></img>
                </div>
                <div>
                    <img className={classes.header__userImage} src="./user.png" alt="User" onClick={props.toggleMenu}></img>
                    {
                        props.isMenuOpened &&
                        <div className={classes.header__menu}>
                            <input className={classes.header__menuItem} type="button" value="Войти"></input>
                            <input className={classes.header__menuItem} type="button" value="FAQ"></input>
                        </div>
                    }
                </div>
            </div>
        </header>
    );
}

Header.propTypes = {
    toggleMenu: PropTypes.func,
    goToMainPage: PropTypes.func,
    isMenuOpened: PropTypes.bool,
}

export default Header;