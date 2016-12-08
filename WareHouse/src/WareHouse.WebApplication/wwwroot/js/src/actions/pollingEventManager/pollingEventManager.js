import {
  CHANGE_OR_ADD_ITEM,
  CHANGE_OR_ADD_SUPPLY,
  CHANGE_OR_ADD_ORDER,
} from '../../constants/pollingEventManager/pollingEventManager'

export function ChangeOrAddItem(data) {

  return (dispatch) => {
    dispatch({
      type: CHANGE_OR_ADD_ITEM,
      payload: data
    })
  }
}

export function ChangeOrAddSupply(data) {

  return (dispatch) => {
    dispatch({
      type: CHANGE_OR_ADD_SUPPLY,
      payload: data
    })
  }
}

export function ChangeOrAddOrder(data) {

  return (dispatch) => {
    dispatch({
      type: CHANGE_OR_ADD_ORDER,
      payload: data
    })
  }
}
