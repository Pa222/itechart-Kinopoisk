import React from "react";
import { Redirect, Route } from "react-router";
import Store from '../Redux/Store';

const ProtectedRoute = ({component: Comp, ...rest}) => {

    return (
        <Route
            {...rest}
            render={props => {
                if (Store.getState().userState.authorized){
                    return <Comp {...props} />
                }
                return <Redirect to={{
                    pathname: '/',
                }} />
            }}
        />
    );
}

export default ProtectedRoute;