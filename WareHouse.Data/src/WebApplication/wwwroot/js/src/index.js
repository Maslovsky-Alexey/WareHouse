import React from 'react'
import { render } from 'react-dom'
import { createStore } from 'redux'
import { Provider } from 'react-redux'
import configureStore from './store/configureStore'

import { Router, Route, browserHistory } from 'react-router'
import { syncHistoryWithStore } from 'react-router-redux'

//import containers begin
import Layout from './containers/Layout'
import WarehouseItems from './containers/WarehouseItems'
import Profile from './containers/Profile'
//import containers end


const store = configureStore()

const history = syncHistoryWithStore(browserHistory, store)

render(
  <Provider store={store}>
    <Router history={history}>
      <Route component={Layout}>
        <Route path="/" component={Profile}/>
        <Route path="/items" component={WarehouseItems}/>
      </Route>
    </Router>
  </Provider>,
  document.getElementById('root')
)
