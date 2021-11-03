import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles({
    wrapper: {
        margin: "0 auto",
        maxWidth: "1280px",
        height: "1000px",
        backgroundColor: "#f4f4f4",
    },
    wrapper__loadingContainer: {
        display: "flex",
        justifyContent: "center",
    },
    wrapper__loading: {
        width: "100px",
    },
    wrapper__catalogContainer: {
        display: "flex",
        flexDirection: "row",
        flexWrap: "wrap",
        justifyContent: "space-between",
    }
});

export default useStyles;