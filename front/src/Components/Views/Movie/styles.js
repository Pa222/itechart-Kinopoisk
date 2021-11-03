import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles({
    movie: {
        margin: "40px",
        maxWidth: "200px",
    },
    movie__poster: {
        height: "294px",
    },
    movie__title: {
        marginBottom: "0",
        fontSize: "20px",
        textAlign: "center",
        wordBreak: "break-all",
    },
    movie__year: {
        margin: "0",
        fontSize: "12px",
        textAlign: "center",
    }
});

export default useStyles;