import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { HashRouter } from 'react-router-dom';
import App from './App';
import Store from './Redux/Store';

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
