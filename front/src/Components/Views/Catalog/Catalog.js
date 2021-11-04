import React from "react";
import PropTypes from 'prop-types'
import { Pagination } from "@mui/material";
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
                    <div className={classes.wrapper__catalog}>
                        {
                            props.movies.map((movie) => <Movie key={movie.id} {...movie}/>)
                        }
                    </div>
                    <Pagination 
                        className={classes.wrapper__pagination}
                        count={10} 
                        shape="rounded"
                        hidePrevButton
                        hideNextButton
                        page={props.page}
                        onChange={props.changePage}
                    />
                </div>
            }
            
        </div>
    );
}

Catalog.propTypes = {
    isLoading: PropTypes.bool,
    movies: PropTypes.array,
    page: PropTypes.number,
    changePage: PropTypes.func,
}

export default Catalog;