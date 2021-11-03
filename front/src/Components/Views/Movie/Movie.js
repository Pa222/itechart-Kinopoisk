import React from "react";
import useStyles from "./styles";

const Movie = (props) => {
    const classes = useStyles();
    return (
        <div className={classes.movie}>
            <img className={classes.movie__poster} src={props.image} alt={props.Title}></img>
            <p className={classes.movie__title}>{props.title}</p>
            <p className={classes.movie__year}>({props.createYear})</p>
        </div>
    );
}

export default Movie;