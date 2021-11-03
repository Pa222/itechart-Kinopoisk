import React, {useState} from "react";
import Header from '../Views/Header/Header';

const HeaderContainer = () => {
    const [isMenuOpened, setIsMenuOpened] = useState(false);

    const toggleMenu = () => setIsMenuOpened(!isMenuOpened);

    const headerProps = {
        toggleMenu,
        isMenuOpened,
    }

    return (
        <Header {...headerProps}/>
    );
}

export default HeaderContainer;