import React, {useState, useEffect} from "react";
import { useHistory } from "react-router";
import Catalog from "../Views/Catalog/Catalog";

const CatalogContainer = () => {
    const [movies, setMovies] = useState();
    const [page, setPage] = useState(1);
    const [totalPages, setTotalPages] = useState(1);
    const [loading, setLoading] = useState(true);
    const history = useHistory();

    useEffect(() => {
        (async () => {
            setLoading(true);

            let response = await fetch(`http://localhost:28880/api/Catalog/get-page/1`);
            let json = await response.json();

            setMovies(json.movies);
            setTotalPages(json.totalPages);

            setLoading(false);
        })()
    }, [])

    const changePage = async (e, pageNumber) => {
        setLoading(true);

        let response = await fetch(`http://localhost:28880/api/Catalog/get-page/${pageNumber}`);
        let json = await response.json();

        setMovies(json.movies);
        setPage(json.pageNumber);
        setTotalPages(json.totalPages);

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