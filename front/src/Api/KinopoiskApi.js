import { getCookie } from "../Utils/Cookies";

const ip = "localhost";
const port = 4000;

class KinopoiskApi{

    static getMoviesPage = async (page, size = 8) => {
        const response = await fetch(`http://${ip}:${port}/api/Catalog/get-page?page=${page}&size=${size}`);
        return await response.json();
    }

    static getFaqs = async () => {
        const response = await fetch(`http://${ip}:${port}/api/Faq`);
        return await response.json();
    }

    static getMovieById = async (id) => {
        const response = await fetch(`http://${ip}:${port}/api/Catalog/get?id=${id}`);
        return await response.json();
    }

    static getMoviesByTitle = async (title) => {
        if (typeof title === "string"){
            const response = await fetch(`http://${ip}:${port}/api/Catalog/get-by-title?title=${title}`);
            return await response.json();
        }
    }

    static auth = async (email, password) => {
        const response = await fetch(`http://${ip}:${port}/api/User/auth`, {
                method: "POST",
                headers:{
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({email, password}),
            });
        if (response.status === 401){
            return null;
        }
        const token = await response.text();
        return token;
    }

    static getUser = async () => {
        const response = await fetch(`http://${ip}:${port}/api/User/get-user`, {
            method: "GET",
            headers: {
                'Authorization': `Bearer ${getCookie("AuthToken")}`
            }
        });
        if (response.status === 401){
            return null;
        }
        return await response.json();
    }

    static register = async (user) => {
        const response = await fetch(`http://${ip}:${port}/api/User/register`, {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(user),
        })
        return response.code === 200;
    }
}

export default KinopoiskApi;