import {
  GET_USER_INFORMATION_REQUEST,
  GET_USER_INFORMATION_SUCCESS,
  GET_USER_INFORMATION_FAILED
} from '../../constants/profile/about'

import AccountRepository from '../../repositories/AccountRepository'


export function getUserInformation() {

  return (dispatch) => {
    dispatch({
      type: GET_USER_INFORMATION_REQUEST,
      payload: {}
    })

    new AccountRepository().getCurrentUser((data) => {
      if (data != null){
        dispatch({
          type: GET_USER_INFORMATION_SUCCESS,
          payload: data
        })
      }
      else{
        dispatch({
          type: GET_USER_INFORMATION_FAILED,
          payload: {errorMessage: "please reauthorize and reload this page"}
        })
      }
    });
  }
}
