import React from "react";
import PropTypes from 'prop-types'
import useStyles from "./styles";
import Movie from "../Movie/Movie";

const Catalog = (props) => {
    const classes = useStyles();
    return (
        <div className={classes.wrapper}>
            {
                props.isLoading &&
                <div className={classes.wrapper__loadingContainer}>
                    <img className={classes.wrapper__loading} src="./Loading.gif" alt="Loading..."></img>
                </div>
            }
            {
                !props.isLoading &&
                <div className={classes.wrapper__catalogContainer}>
                    {
                        props.movies.map((movie) => <Movie key={movie.Id} {...movie}/>)
                    }
                </div>
            }
            
        </div>
    );
}

Catalog.propTypes = {
    isLoading: PropTypes.bool,
    movies: PropTypes.array,
}

export default Catalog;