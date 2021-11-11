import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles({
    container: {
        display: "flex",
        flexDirection: "row",
    },
    container__info: {
        fontSize: "20px",
        "&:last-child": {
            marginLeft: "20px",
        }
    }
});

export default useStyles;