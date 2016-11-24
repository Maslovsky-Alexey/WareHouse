import {
  GET_ORDERS_REQUEST,
  GET_ORDERS_SUCCESS,
  GET_ORDERS_FAILED,

  CONFIRM_ORDER_REQUEST,
  CONFIRM_ORDER_SUCCESS,

  RETURN_ORDER_REQUEST,
  RETURN_ORDER_SUCCESS
} from '../../constants/orders/orders'

const initialState = {
  items: [],
  errorMessage: null
}

export default function orders(state = initialState, action) {
  switch (action.type) {
   case GET_ORDERS_REQUEST:
     return Object.assign({}, state, {
       errorMessage: null
     })

   case GET_ORDERS_SUCCESS:
     return Object.assign({}, state, {
       items: action.payload,
       errorMessage: null
     })

    case GET_ORDERS_FAILED:
      return Object.assign({}, state, {
        items: [],
        errorMessage: action.payload.errorMessage
      })

    case CONFIRM_ORDER_REQUEST:
      return Object.assign({}, state, {
      })

    case CONFIRM_ORDER_SUCCESS:
      return Object.assign({}, state, {
      })

    case RETURN_ORDER_REQUEST:
      return Object.assign({}, state, {
      })

    case RETURN_ORDER_SUCCESS:
      return Object.assign({}, state, {
      })

     default:
       return state;
   }
}
