import {
  GET_SUPPLIES_REQUEST,
  GET_SUPPLIES_SUCCESS,
  GET_SUPPLIES_FAILED,

  CONFIRM_SUPPLY_REQUEST,
  CONFIRM_SUPPLY_SUCCESS,

  RETURN_SUPPLY_REQUEST,
  RETURN_SUPPLY_SUCCESS,

  ADD_SUPPLY_REQUEST,
  ADD_SUPPLY_SUCCESS
} from '../../constants/supplies/supplies'

import {
  CHANGE_OR_ADD_SUPPLY,
} from '../../constants/pollingEventManager/pollingEventManager'

const initialState = {
  items: [],
  ready: true,
  errorMessage: null
}

export default function supplies(state = initialState, action) {
  switch (action.type) {

   case GET_SUPPLIES_REQUEST:
   case ADD_SUPPLY_REQUEST:
   case RETURN_SUPPLY_REQUEST:
   case CONFIRM_SUPPLY_REQUEST:
     return Object.assign({}, state, {
       errorMessage: null,
       ready: false
     })

   case ADD_SUPPLY_SUCCESS:
   case RETURN_SUPPLY_SUCCESS:
   case CONFIRM_SUPPLY_SUCCESS:
     return Object.assign({}, state, {
       errorMessage: null,
       ready: true
     })

   case GET_SUPPLIES_SUCCESS:
     return Object.assign({}, state, {
       items: action.payload,
       ready: true,
       errorMessage: null
     })

    case GET_SUPPLIES_FAILED:
      return Object.assign({}, state, {
        items: [],
        ready: true,
        errorMessage: action.payload.errorMessage
      })

    case CHANGE_OR_ADD_SUPPLY:
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
