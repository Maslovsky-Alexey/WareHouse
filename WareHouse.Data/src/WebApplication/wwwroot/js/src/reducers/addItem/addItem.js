import {
  ADD_ITEM_REQUEST,
  ADD_ITEM_SUCCESS
} from '../../constants/addItem/items';

const initialState = {
  ready: true,
  errorMessage: null
}

export default function addItem(state = initialState, action) {
  switch (action.type) {
   case ADD_ITEM_REQUEST:
     return Object.assign({}, state, {
       errorMessage: null,
       ready: false
     })

   case ADD_ITEM_SUCCESS:
     return Object.assign({}, state, {
       errorMessage: null,
       ready: true
     })

     default:
       return state;
   }
}
