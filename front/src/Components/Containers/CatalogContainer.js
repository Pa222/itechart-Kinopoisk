import React, {useState, useEffect} from "react";
import { useHistory } from "react-router";
import KinopoiskApi from "../../Api/KinopoiskApi";
import Catalog from "../Views/Catalog/Catalog";

const CatalogContainer = () => {
    const [movies, setMovies] = useState([]);
    const [page, setPage] = useState(1);
    const [totalPages, setTotalPages] = useState(1);
    const [loading, setLoading] = useState(true);
    const history = useHistory();

    useEffect(() => {
        (async () => {
            setLoading(true);

            let response = await KinopoiskApi.getMoviesPage(1);
            if (response === null){
                return;
            }

            setMovies(response.movies);
            setTotalPages(response.totalPages);

            setLoading(false);
        })()
    }, [])

    const changePage = async (e, pageNumber) => {
        setLoading(true);

        let response = await KinopoiskApi.getMoviesPage(pageNumber);

        setMovies(response.movies);
        setPage(response.pageNumber);
        setTotalPages(response.totalPages);

        setLoading(false);
    }

    const openMoviePage = (id) => {
        history.push(`movie/${id}`);
    }

    const catalogProps = {
        loading,
        movies,
        page,
        changePage,
        totalPages,
        openMoviePage,
    };

    return (
        <Catalog {...catalogProps} />
    );
}

export default CatalogContainer;