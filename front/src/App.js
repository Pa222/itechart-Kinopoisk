import React from 'react';
import { Route, Switch } from 'react-router';
import ProtectedRoute from './Components/ProtectedRoute';
import CatalogContainer from './Components/Containers/CatalogContainer';
import HeaderContainer from './Components/Containers/HeaderContainer';
import MoviePageContainer from './Components/Containers/MoviePageContainer';
import FaqContainer from './Components/Containers/FaqContainer';
import LoginContainer from './Components/Containers/LoginContainer';
import RegistrationContainer from './Components/Containers/RegistrationContainer';
import Footer from './Components/Views/Footer/Footer';
import ErrorPage from './Components/Views/ErrorPage/ErrorPage';
import ProfileContainer from './Components/Containers/ProfileContainer';

const App = () => {
    return (
        <div>
            <HeaderContainer/>
            <Switch>
                <Route 
                    exact
                    path={['/', '/index']}
                    render={() =>
                        <CatalogContainer/>
                    }
                />
                <Route 
                    path={'/movie'}
                    render={() =>
                        <MoviePageContainer/>
                    }
                />
                <Route 
                    path={'/faq'}
                    render={() =>
                        <FaqContainer/>
                    }
                />
                <Route
                    path={'/login'}
                    render={() => 
                        <LoginContainer/>
                    }
                />
                <Route
                    path={'/register'}
                    render={() => 
                        <RegistrationContainer/>
                    }
                />
                <ProtectedRoute
                    path={'/profile'}
                    component={ProfileContainer}
                />
                <Route 
                    render={() =>
                        <ErrorPage/>
                    }
                />
            </Switch>
            <Footer/>
        </div>
    );
}

export default App;