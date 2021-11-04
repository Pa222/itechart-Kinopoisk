import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles({
    wrapper: {
        margin: "0 auto",
        maxWidth: "1280px",
        backgroundColor: "#f4f4f4",
    },
    wrapper__loadingContainer: {
        display: "flex",
        minHeight: "900px",
        justifyContent: "center",
    },
    wrapper__loading: {
        width: "100px",
        height: "100px",
    },
    wrapper__catalogContainer: {
        minHeight: "900px",
        display: "flex",
        flexDirection: "column",
    },
    wrapper__catalog: {
        minHeight: "832px",
        display: "flex",
        flexDirection: "row",
        flexWrap: "wrap",
        justifyContent: "space-between",
    },
    wrapper__pagination: {
        margin: "0 auto 50px auto",
    },
});

export default useStyles;