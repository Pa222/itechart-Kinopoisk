import React from 'react';
import { Route, Switch } from 'react-router';
import CatalogContainer from './Components/Containers/CatalogContainer';
import HeaderContainer from './Components/Containers/HeaderContainer';

const App = () => {
    return (
        <div>
            <Switch>
                <Route 
                    exact
                    path={['/', '/index']}
                    render={() =>
                        <div>
                            <HeaderContainer/>
                            <CatalogContainer/>
                        </div>
                    }
                />
            </Switch>
        </div>
    );
}

export default App;