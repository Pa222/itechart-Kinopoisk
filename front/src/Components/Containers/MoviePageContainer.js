import React, {useEffect} from "react";
import { connect } from "react-redux";
import { useHistory } from "react-router";
import { fetchMovieAsync } from "../../Redux/Actions";
import MoviePage from "../Views/MoviePage/MoviePage";

const MoviePageContainer = (props) => {
    const history = useHistory();

    useEffect(() => {
        (() => {
            const id = history.location.pathname.match(/(\d+)/)[0];
            props.getMovie(id);
        })()
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
        title: state.movie.title,
        image: state.movie.image,
        createYear: state.movie.createYear,
        description: state.movie.description,
        genres: state.movie.genreMovies,
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        getMovie: (id) => dispatch(fetchMovieAsync(id)),
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(MoviePageContainer);