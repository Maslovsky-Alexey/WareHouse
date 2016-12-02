import {
  GET_ITEMS_REQUEST,
  GET_ITEMS_SUCCESS,
  GET_ITEMS_FAILED
} from '../../constants/items/items'

const initialState = {
  items: [],
  errorMessage: null
}

export default function items(state = initialState, action) {
  switch (action.type) {
   case GET_ITEMS_REQUEST:
     return Object.assign({}, state, {
       errorMessage: null
     })

   case GET_ITEMS_SUCCESS:
     return Object.assign({}, state, {
       items: action.payload,
       errorMessage: null
     })

    case GET_ITEMS_FAILED:
      return Object.assign({}, state, {
        errorMessage: action.payload.errorMessage
      })

     default:
       return state;
   }
}
