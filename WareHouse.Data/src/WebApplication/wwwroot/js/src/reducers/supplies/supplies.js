import {
  GET_SUPPLIES_REQUEST,
  GET_SUPPLIES_SUCCESS,
  GET_SUPPLIES_FAILED,

  CONFIRM_SUPPLY_REQUEST,
  CONFIRM_SUPPLY_SUCCESS,

  RETURN_SUPPLY_REQUEST,
  RETURN_SUPPLY_SUCCESS
} from '../../constants/supplies/supplies'

const initialState = {
  items: [],
  errorMessage: null
}

export default function supplies(state = initialState, action) {
  switch (action.type) {
   case GET_SUPPLIES_REQUEST:
     return Object.assign({}, state, {
       errorMessage: null
     })

   case GET_SUPPLIES_SUCCESS:
     return Object.assign({}, state, {
       items: action.payload,
       errorMessage: null
     })

    case GET_SUPPLIES_FAILED:
      return Object.assign({}, state, {
        items: [],
        errorMessage: action.payload.errorMessage
      })

    case CONFIRM_SUPPLY_REQUEST:
      return Object.assign({}, state, {
      })

    case CONFIRM_SUPPLY_SUCCESS:
      return Object.assign({}, state, {
      })

    case RETURN_SUPPLY_REQUEST:
      return Object.assign({}, state, {
      })

    case RETURN_SUPPLY_SUCCESS:
      return Object.assign({}, state, {
      })

     default:
       return state;
   }
}
