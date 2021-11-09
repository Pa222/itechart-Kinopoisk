
const port = 4000;

class KinopoiskApi{

    static getMoviesPage = async (page, size = 8) => {
        let response = await fetch(`http://localhost:${port}/api/Catalog/get-page?page=${page}&size=${size}`);
        return await response.json();
    }

    static getFaqs = async () => {
        let response = await fetch(`http://localhost:${port}/api/Faq`);
        return await response.json();
    }

    static getMovieById = async (id) => {
        let response = await fetch(`http://localhost:${port}/api/Catalog/get?id=${id}`);
        return await response.json();
    }

    static getMoviesByTitle = async (title) => {
        if (typeof title === "string"){
            let response = await fetch(`http://localhost:${port}/api/Catalog/get-by-title?title=${title}`);
            return await response.json();
        }
    }

    static auth = async (email, password) => {
        let response = await fetch(`http://localhost:${port}/api/User/auth`, {
                method: "POST",
                headers:{
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({email, password}),
            });
        if (response.status === 401){
            return {
                auth: false,
            }
        }
        const json = await response.json();
        return {
            auth: true,
            ...json,
        }
    } 
}

export default KinopoiskApi;