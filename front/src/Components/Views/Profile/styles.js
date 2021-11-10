import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles({
    wrapper: {
        margin: "0 auto",
        maxWidth: "1280px",
        backgroundColor: "#f4f4f4",
    },
    wrapper__profileContainer: {
        minHeight: "900px",
        display: "flex",
        flexDirection: "column",
    },
});

export default useStyles;