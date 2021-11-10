import Cookies from "universal-cookie/es6";

const cookies = new Cookies();

export const addCookie = (name, value) => {
    cookies.set(name, value);
}

export const getCookies = () => {
    return cookies.getAll();
}

export const getCookie = (name) => {
    return cookies.get(name);
}