import {
  ADD_EMPLOYEE_REQUEST,
  ADD_EMPLOYEE_SUCCESS,
  ADD_EMPLOYEE_FAILED,

  ADD_CLIENT_REQUEST,
  ADD_CLIENT_SUCCESS,
  ADD_CLIENT_FAILED
} from  '../../constants/profile/admin'

import AccountRepository from '../../repositories/AccountRepository'


export function addClient(username) {

  return (dispatch) => {
    dispatch({
      type: ADD_CLIENT_REQUEST,
      payload: {}
    })

    new AccountRepository().addClientRole(username, (data) => {
      if (data != null){
        dispatch({
          type: ADD_EMPLOYEE_SUCCESS,
          payload: data
        })
      }
      else{
        dispatch({
          type: ADD_CLIENT_FAILED,
          payload: {errorMessage: "error, repeat again"}
        })
      }
    });
  }
}

export function addEmployee(username) {

  return (dispatch) => {
    dispatch({
      type: ADD_EMPLOYEE_REQUEST,
      payload: {}
    })

    new AccountRepository().addEmployeeRole(username, (data) => {
      if (data != null){
        dispatch({
          type: ADD_EMPLOYEE_SUCCESS,
          payload: data
        })
      }
      else{
        dispatch({
          type: ADD_EMPLOYEE_FAILED,
          payload: {errorMessage: "error, repeat again"}
        })
      }
    });
  }
}
