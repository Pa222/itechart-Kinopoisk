import React from "react";
import { Route } from "react-router";

const ProtectedRoute = ({component: Comp, ...rest}) => {

    return (
        <Route
            {...rest}
            render={props => {
                return <Comp {...props} />
            }}
        />
    );
}

export default ProtectedRoute;