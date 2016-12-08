import React from 'react';
import { render } from 'react-dom';
import { createStore } from 'redux';
import { Provider } from 'react-redux';
import configureStore from './store/configureStore';

import { Router, Route, browserHistory } from 'react-router';
import { syncHistoryWithStore } from 'react-router-redux';

//import containers begin
import AppContainer from './containers/AppContainer';
import Layout from './containers/Layout';
import WarehouseItems from './containers/WarehouseItems';
import Profile from './containers/Profile';
import AddItem from './containers/AddItem';
import Operations from './containers/Operations';
//import containers end


const store = configureStore();

const history = syncHistoryWithStore(browserHistory, store);

render(
  <Provider store={store}>
    <Router history={history}>
      <Route component={AppContainer}>
        <Route component={Layout}>
          <Route path="/" component={Profile}/>
          <Route path="/items" component={WarehouseItems}/>
          <Route path="/additem" component={AddItem}/>
          <Route path="/operations" component={Operations}/>
        </Route>
      </Route>
    </Router>
  </Provider>,
  document.getElementById('root')
);
