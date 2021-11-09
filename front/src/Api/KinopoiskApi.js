
class KinopoiskApi{
    static getMoviesPage = async (page, size = 8) => {
        let response = await fetch(`http://localhost:28880/api/Catalog/get-page?page=${page}&size=${size}`);
        return await response.json();
    }

    static getFaqs = async () => {
        let response = await fetch(`http://localhost:28880/api/Faq`);
        return await response.json();
    }

    static getMovieById = async (id) => {
        let response = await fetch(`http://localhost:28880/api/Catalog/get?id=${id}`);
        return await response.json();
    }

    static getMoviesByTitle = async (title) => {
        if (typeof title === "string"){
            let response = await fetch(`http://localhost:28880/api/Catalog/get-by-title?title=${title}`);
            return await response.json();
        }
    }
}

export default KinopoiskApi;