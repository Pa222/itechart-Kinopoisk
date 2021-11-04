import React from 'react';
import { Route, Switch } from 'react-router';
import CatalogContainer from './Components/Containers/CatalogContainer';
import HeaderContainer from './Components/Containers/HeaderContainer';
import Footer from './Components/Views/Footer/Footer';

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
                            <Footer/>
                        </div>
                    }
                />
            </Switch>
        </div>
    );
}

export default App;