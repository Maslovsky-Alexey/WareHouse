import {
  GET_ORDERS_REQUEST,
  GET_ORDERS_SUCCESS,
  GET_ORDERS_FAILED,

  CONFIRM_ORDER_REQUEST,
  CONFIRM_ORDER_SUCCESS,

  RETURN_ORDER_REQUEST,
  RETURN_ORDER_SUCCESS
} from '../../constants/orders/orders'

import OrdersRepository from '../../repositories/OrdersRepository'
import OperationsRepository from '../../repositories/OperationsRepository'

export function getOrders(clientName) {

  return (dispatch) => {
    dispatch({
      type: GET_ORDERS_REQUEST,
      payload: {}
    })

    let success = (data) => {
      if (data != null){
        dispatch({
          type: GET_ORDERS_SUCCESS,
          payload: data
        })
      }
      else{
        dispatch({
          type: GET_ORDERS_FAILED,
          payload: {errorMessage: "please reload this page"}
        })
      }
    }

    if (clientName == null){
      new OrdersRepository().getOrders(success);
    }
    else{
      new OrdersRepository().getClientOrders(clientName, success);
    }
  }
}

export function confirmOrder(orderId){
  return (dispatch) => {
    dispatch({
      type: CONFIRM_ORDER_REQUEST,
      payload: {}
    })

    new OperationsRepository().confirmOrder(orderId, () =>{
      getOrders()(dispatch)
      dispatch({
        type: CONFIRM_ORDER_SUCCESS,
        payload: {}
      })
    })
  }
}

export function returnOrder(orderId){
  return (dispatch) => {
    dispatch({
      type: RETURN_ORDER_REQUEST,
      payload: {}
    })

    new OperationsRepository().returnOrder(orderId, () =>{
      getOrders()(dispatch)
      dispatch({
        type: RETURN_ORDER_SUCCESS,
        payload: {}
      })
    })
  }
}
