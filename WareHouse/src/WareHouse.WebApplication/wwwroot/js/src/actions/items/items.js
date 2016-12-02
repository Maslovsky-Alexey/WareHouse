import {
  GET_ITEMS_REQUEST,
  GET_ITEMS_SUCCESS,
  GET_ITEMS_FAILED
} from '../../constants/items/items'

import ItemsRepository from '../../repositories/ItemsRepository'

export function getItems() {

  return (dispatch) => {
    dispatch({
      type: GET_ITEMS_REQUEST,
      payload: {}
    })

    new ItemsRepository().getItems((data) => {
      if (data != null){
        dispatch({
          type: GET_ITEMS_SUCCESS,
          payload: data
        })
      }
      else{
        dispatch({
          type: GET_ITEMS_FAILED,
          payload: {errorMessage: "please reauthorize and reload this page"}
        })
      }
    });
  }
}
