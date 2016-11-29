import {
  GET_ORDERS_REQUEST,
  GET_ORDERS_SUCCESS,
  GET_ORDERS_FAILED,

  CONFIRM_ORDER_REQUEST,
  CONFIRM_ORDER_SUCCESS,

  RETURN_ORDER_REQUEST,
  RETURN_ORDER_SUCCESS,

  ADD_ORDER_REQUEST,
  ADD_ORDER_SUCCESS
} from '../../constants/orders/orders'

const initialState = {
  items: [],
  ready: true,
  errorMessage: null
}

export default function orders(state = initialState, action) {
  switch (action.type) {

   case GET_ORDERS_REQUEST:
   case CONFIRM_ORDER_REQUEST:
   case RETURN_ORDER_REQUEST:
   case ADD_ORDER_REQUEST:
     return Object.assign({}, state, {
       errorMessage: null,
       ready: false
     })

   case ADD_ORDER_SUCCESS:
   case RETURN_ORDER_SUCCESS:
   case CONFIRM_ORDER_SUCCESS:
     return Object.assign({}, state, {
       errorMessage: null,
       ready: true
     })

   case GET_ORDERS_SUCCESS:
     return Object.assign({}, state, {
       items: action.payload,
       errorMessage: null,
       ready: true
     })

    case GET_ORDERS_FAILED:
      return Object.assign({}, state, {
        items: [],
        errorMessage: action.payload.errorMessage,
        ready: true
      })

     default:
       return state;
   }
}
