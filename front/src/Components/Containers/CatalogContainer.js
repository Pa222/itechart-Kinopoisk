import React, {useState, useEffect} from "react";
import Catalog from "../Views/Catalog/Catalog";

const CatalogContainer = () => {
    const [movies, setMovies] = useState();
    const [page, setPage] = useState(1);
    const [totalPages, setTotalPages] = useState(1);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        (async () => {
            setIsLoading(true);

            let response = await fetch(`http://localhost:28880/api/Catalog/get-page/1`).catch();
            let json = await response.json();

            setMovies(json.movies);
            setTotalPages(json.totalPages);
            setIsLoading(false);
        })()
    }, [])

    const changePage = async (e, pageNumber) => {
        setIsLoading(true);

        let response = await fetch(`http://localhost:28880/api/Catalog/get-page/${pageNumber}`).catch();
        let json = await response.json();

        setMovies(json.movies);
        setIsLoading(false);
        setPage(json.pageNumber);
        setTotalPages(json.totalPages);
    }

    const catalogProps = {
        isLoading,
        movies,
        page,
        changePage,
        totalPages,
    };

    return (
        <Catalog {...catalogProps} />
    );
}

export default CatalogContainer;