import React, {useState, useEffect} from "react";
import { useHistory } from "react-router";
import { connect } from "react-redux";
import PropTypes from 'prop-types';
import KinopoiskApi from "../../Api/KinopoiskApi";
import Header from '../Views/Header/Header';
import { fetchMovieAsync } from "../../Redux/Actions";

const HeaderContainer = (props) => {
    const [menuOpened, setMenuOpened] = useState(false);
    const [searchText, setSearchText] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const history = useHistory();

    useEffect(() => {
        (async () => {
            let response = await KinopoiskApi.getMoviesByTitle(searchText);
            setSearchResults(response.slice(0, 5));
        })();
    }, [searchText]);

    const toggleMenu = () => setMenuOpened(!menuOpened);

    const handleSearchBoxChange = (e) => setSearchText(e.target.value); 

    const goToMoviePage = (id) => {
        history.push(`/movie/${id}`);
        props.getMovie(id);
        
        setSearchText('');
        document.querySelector("input[name='searchbox']").value = "";
    }

    const goToMainPage = () => history.push('/');

    const goToFaqPage = () => {
        history.push('/faq');
        toggleMenu();
    }

    const goToLoginPage = () => {
        history.push('/login');
        toggleMenu();
    }

    const headerProps = {
        menuOpened,
        searchText,
        searchResults,
        toggleMenu,
        goToMainPage,
        goToFaqPage,
        goToMoviePage,
        goToLoginPage,
        handleSearchBoxChange,
    }

    return (
        <Header {...headerProps}/>
    );
}

const mapDispatchToProps = (dispatch) => {
    return {
        getMovie: (id) => dispatch(fetchMovieAsync(id)),
    }
}

HeaderContainer.propTypes = {
    getMovie: PropTypes.func,
}

export default connect(null, mapDispatchToProps)(HeaderContainer);