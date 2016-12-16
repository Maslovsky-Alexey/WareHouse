import {
  ADD_ITEM_REQUEST,
  ADD_ITEM_SUCCESS
} from '../../constants/addItem/items';

import OperationsRepository from '../../repositories/OperationsRepository'

export function addItem(itemName, desc, b64, success) {

  return (dispatch) => {
    dispatch({
      type: ADD_ITEM_REQUEST,
      payload: {}
    });


    new OperationsRepository().addItemWithoutRepetition(itemName, desc, b64, () => {
        success();
        dispatch({
          type: ADD_ITEM_SUCCESS,
          payload: {}
        })
      });
  }
}
