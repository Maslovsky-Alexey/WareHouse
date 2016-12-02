import {
  GET_PAGE_WAREHOUSE_ITEMS_REQUEST,
  GET_PAGE_WAREHOUSE_ITEMS_SUCCESS,
  GET_PAGE_WAREHOUSE_ITEMS_FAILED,
} from '../../constants/warehouseItems/warehouseItems'

import WarehouseItemsRepository from '../../repositories/WarehouseItemsRepository'

export function getPageWarehouseItems(pageNumber, filter) {

  return (dispatch) => {
    dispatch({
      type: GET_PAGE_WAREHOUSE_ITEMS_REQUEST,
      payload: {}
    })

    let success = (data) => {
      if (data != null){
        dispatch({
          type: GET_PAGE_WAREHOUSE_ITEMS_SUCCESS,
          payload: data
        })
      }
      else{
        dispatch({
          type: GET_PAGE_WAREHOUSE_ITEMS_FAILED,
          payload: {errorMessage: "please reload this page"}
        })
      }
    }

    new WarehouseItemsRepository().getPageItemsWithFilter(success, pageNumber, filter)
  }
}
