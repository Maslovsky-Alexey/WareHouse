import { combineReducers } from 'redux'

import about from './profile/about'
import admin from './profile/admin'
import orders from './orders/orders'
import supplies from './supplies/supplies'
import page from './warehouseItems/warehouseItems'
import items from './items/items'
import addItem from './addItem/addItem'

import { routerReducer } from 'react-router-redux'

export default combineReducers({
  about,
  orders,
  supplies,
  admin,
  page,
  items,
  addItem,
  routing: routerReducer
})
