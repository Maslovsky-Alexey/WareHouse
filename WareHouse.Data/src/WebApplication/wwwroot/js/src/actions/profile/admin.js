import {
  ADD_EMPLOYEE_REQUEST,
  ADD_EMPLOYEE_SUCCESS,
  ADD_EMPLOYEE_FAILED,

  ADD_CLIENT_REQUEST,
  ADD_CLIENT_SUCCESS,
  ADD_CLIENT_FAILED,

  GET_PROVIDERS_REQUEST,
  GET_PROVIDERS_SUCCESS,
  GET_PROVIDERS_FAILED,

  GET_CLIENTS_REQUEST,
  GET_CLIENTS_SUCCESS,
  GET_CLIENTS_FAILED,

  ADD_PROVIDER_REQUEST,
  ADD_PROVIDER_SUCCESS
} from  '../../constants/profile/admin'

import AccountRepository from '../../repositories/AccountRepository'

import ActorsRepository from '../../repositories/ActorsRepository'

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

export function getProviders() {

  return (dispatch) => {
    dispatch({
      type: GET_PROVIDERS_REQUEST,
      payload: {}
    })

    new ActorsRepository().getProviders((data) => {
      if (data != null){
        dispatch({
          type: GET_PROVIDERS_SUCCESS,
          payload: data
        })
      }
      else{
        dispatch({
          type: GET_PROVIDERS_FAILED,
          payload: {errorMessage: "error, repeat again"}
        })
      }
    })
  }
}

export function getClients() {
  return (dispatch) => {
    dispatch({
      type: GET_CLIENTS_REQUEST,
      payload: {}
    })

    new ActorsRepository().getClients((data) => {
      if (data != null){
        dispatch({
          type: GET_CLIENTS_SUCCESS,
          payload: data
        })
      }
      else{
        dispatch({
          type: GET_CLIENTS_FAILED,
          payload: {errorMessage: "error, repeat again"}
        })
      }
    })
  }
}

export function addProvider(provider) {
  return (dispatch) => {
    dispatch({
      type: ADD_PROVIDER_REQUEST,
      payload: {}
    })

    new ActorsRepository().addProvder(() => {
      if (data != null){
        dispatch({
          type: ADD_PROVIDER_SUCCESS,
          payload: {}
        })
      }
    })
  }
}
