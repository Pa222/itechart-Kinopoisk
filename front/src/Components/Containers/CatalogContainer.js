import React, {useState, useEffect} from "react";
import Catalog from "../Views/Catalog/Catalog";

const CatalogContainer = () => {
    const [movies, setMovies] = useState();
    const [isLoading, setIsLoading] = useState(true);

    useEffect(()=>{
        (async () => {
            setIsLoading(true);
            let response = await fetch('http://localhost:28880/api/Catalog/get').catch();
            let json = await response.json();
            setMovies(json);
            setIsLoading(false);
        })();
    }, []);

    const catalogProps = {
        isLoading,
        movies,
    };

    return (
        <Catalog {...catalogProps} />
    );
}

export default CatalogContainer;