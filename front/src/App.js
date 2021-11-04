import React from 'react';
import { Route, Switch } from 'react-router';
import CatalogContainer from './Components/Containers/CatalogContainer';
import HeaderContainer from './Components/Containers/HeaderContainer';
import MoviePageContainer from './Components/Containers/MoviePageContainer';
import Footer from './Components/Views/Footer/Footer';
import ErrorPage from './Components/Views/ErrorPage';

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
                <Route 
                    path={'/movie/'}
                    render={() =>
                        <div>
                            <HeaderContainer/>
                            <MoviePageContainer/>
                            <Footer/>
                        </div>
                    }
                />
                <Route 
                    render={() =>
                        <ErrorPage/>
                    }
                />
            </Switch>
        </div>
    );
}

export default App;