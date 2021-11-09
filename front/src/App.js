import React from 'react';
import { Route, Switch } from 'react-router';
import CatalogContainer from './Components/Containers/CatalogContainer';
import HeaderContainer from './Components/Containers/HeaderContainer';
import MoviePageContainer from './Components/Containers/MoviePageContainer';
import Footer from './Components/Views/Footer/Footer';
import ErrorPage from './Components/Views/ErrorPage';

import Store from './Redux/Store';
import FaqContainer from './Components/Containers/FaqContainer';
import LoginContainer from './Components/Containers/LoginContainer';
import RegistrationContainer from './Components/Containers/RegistrationContainer';

window.store = Store;

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
                    path={'/movie/:int'}
                    render={() =>
                        <div>
                            <HeaderContainer/>
                            <MoviePageContainer/>
                            <Footer/>
                        </div>
                    }
                />
                <Route 
                    path={'/faq'}
                    render={() =>
                        <div>
                            <HeaderContainer/>
                            <FaqContainer/>
                            <Footer/>
                        </div>
                    }
                />
                <Route
                    path={'/login'}
                    render={() => 
                        <div>
                            <HeaderContainer/>
                            <LoginContainer/>
                            <Footer/>
                        </div>
                    }
                />
                <Route
                    path={'/register'}
                    render={() => 
                        <div>
                            <HeaderContainer/>
                            <RegistrationContainer/>
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