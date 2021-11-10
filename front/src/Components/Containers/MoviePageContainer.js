import React, {useEffect} from "react";
import PropTypes from 'prop-types';
import { connect } from "react-redux";
import { useHistory } from "react-router";
import { cleanMovie, fetchMovieAsync } from "../../Redux/Actions";
import MoviePage from "../Views/MoviePage/MoviePage";

const MoviePageContainer = (props) => {
    const history = useHistory();

    useEffect(() => {
        const id = history.location.pathname.match(/(\d+)/)[0];
        props.getMovie(id);

        return () => {
            props.cleanMovie();
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    const moviePageProps = {
        title: props.title,
        image: props.image,
        createYear: props.createYear,
        description: props.description,
        genres: props.genres,
    }

    return(
        <MoviePage {...moviePageProps} />
    );
}

const mapStateToProps = (state) => {
    return {
        title: state.movieState.title,
        image: state.movieState.image,
        createYear: state.movieState.createYear,
        description: state.movieState.description,
        genres: state.movieState.genreMovies,
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        getMovie: (id) => dispatch(fetchMovieAsync(id)),
        cleanMovie: () => dispatch(cleanMovie()),
    }
}

MoviePageContainer.propTypes = {
    title: PropTypes.string,
    image: PropTypes.string,
    createYear: PropTypes.string,
    description: PropTypes.string,
    genres: PropTypes.arrayOf(PropTypes.string),
    getMovie: PropTypes.func,
    cleanMovie: PropTypes.func,
}

export default connect(mapStateToProps, mapDispatchToProps)(MoviePageContainer);