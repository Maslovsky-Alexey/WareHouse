import {
  GET_ITEMS_REQUEST,
  GET_ITEMS_SUCCESS,
  GET_ITEMS_FAILED
} from '../../constants/items/items'

import {
  CHANGE_OR_ADD_ITEM,
} from '../../constants/pollingEventManager/pollingEventManager'

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

    case CHANGE_OR_ADD_ITEM:
      let newState = Object.assign({}, state);
      for (let i = 0; i < newState.items.length; i++){
        if (newState.items[i].id == action.payload.id){
          newState.items[i] = action.payload;
          return newState;
        }
      }

      newState.items.push(action.payload);
      return newState;

     default:
       return state;
   }
}
