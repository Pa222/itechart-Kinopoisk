import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { HashRouter } from 'react-router-dom';
import KinopoiskApi from './Api/KinopoiskApi';
import App from './App';
import { updateUser } from './Redux/Actions';
import Store from './Redux/Store';

(async () => {
  var user = await KinopoiskApi.getUser();
  if (user !== null){
    Store.dispatch(updateUser(user));
  }
})()

ReactDOM.render(
  <React.StrictMode>
    <Provider store={Store}>
      <HashRouter>
        <App /> 
      </HashRouter>
    </Provider>
    </React.StrictMode>,
  document.getElementById('root')
);
