import React, {useState} from "react";
import { useHistory } from "react-router";
import Header from '../Views/Header/Header';

const HeaderContainer = () => {
    const [isMenuOpened, setIsMenuOpened] = useState(false);
    const history = useHistory();

    const toggleMenu = () => setIsMenuOpened(!isMenuOpened);

    const goToMainPage = () => {
        history.push('/');
    }

    const goToFaqPage = () => {
        history.push('/faq');
    }

    const headerProps = {
        toggleMenu,
        isMenuOpened,
        goToMainPage,
        goToFaqPage,
    }

    return (
        <Header {...headerProps}/>
    );
}

export default HeaderContainer;