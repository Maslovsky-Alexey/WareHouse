import {
  GET_PAGE_WAREHOUSE_ITEMS_REQUEST,
  GET_PAGE_WAREHOUSE_ITEMS_SUCCESS,
  GET_PAGE_WAREHOUSE_ITEMS_FAILED,
} from '../../constants/warehouseItems/warehouseItems'

const initialState = {
  items: [],
  nextPage: 0,
  prevPage: 0,
  max: 0,
  min: 0,
  errorMessage: null
}

export default function pageWarehouseItems(state = initialState, action) {
  switch (action.type) {
   case GET_PAGE_WAREHOUSE_ITEMS_REQUEST:
     return Object.assign({}, state, {
       errorMessage: null
     })

   case GET_PAGE_WAREHOUSE_ITEMS_SUCCESS:
     return Object.assign({}, state, {
       items: action.payload.items,
       nextPage: action.payload.nextPage,
       prevPage: action.payload.prevPage,
       max: action.payload.max,
       min: action.payload.min,
       errorMessage: null
     })

    case GET_PAGE_WAREHOUSE_ITEMS_FAILED:
      return Object.assign({}, state, {
        errorMessage: action.payload.errorMessage
      })

     default:
       return state;
   }
}
