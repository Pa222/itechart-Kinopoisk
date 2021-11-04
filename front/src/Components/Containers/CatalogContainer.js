import React, {useState, useEffect} from "react";
import { useHistory } from "react-router";
import Catalog from "../Views/Catalog/Catalog";

const CatalogContainer = () => {
    const [movies, setMovies] = useState();
    const [page, setPage] = useState(1);
    const [totalPages, setTotalPages] = useState(1);
    const [isLoading, setIsLoading] = useState(true);
    const history = useHistory();

    useEffect(() => {
        (async () => {
            setIsLoading(true);

            let response = await fetch(`http://localhost:28880/api/Catalog/get-page/1`);
            let json = await response.json();

            setMovies(json.movies);
            setTotalPages(json.totalPages);
            setIsLoading(false);
        })()
    }, [])

    const changePage = async (e, pageNumber) => {
        setIsLoading(true);

        let response = await fetch(`http://localhost:28880/api/Catalog/get-page/${pageNumber}`);
        let json = await response.json();

        setMovies(json.movies);
        setIsLoading(false);
        setPage(json.pageNumber);
        setTotalPages(json.totalPages);
    }

    const openMoviePage = (id) => {
        history.push(`/movie/${id}`);
    }

    const catalogProps = {
        isLoading,
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