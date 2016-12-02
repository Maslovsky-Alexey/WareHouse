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

import SuppliesRepository from '../../repositories/SuppliesRepository'
import OperationsRepository from '../../repositories/OperationsRepository'

export function getSupplies(providerName) {

  return (dispatch) => {
    dispatch({
      type: GET_SUPPLIES_REQUEST,
      payload: {}
    })

    let success = (data) => {
      if (data != null){
        dispatch({
          type: GET_SUPPLIES_SUCCESS,
          payload: data
        })
      }
      else{
        dispatch({
          type: GET_SUPPLIES_FAILED,
          payload: {errorMessage: "please reload this page"}
        })
      }
    }

    if (providerName == null){
      new SuppliesRepository().getSupplies(success);
    }
    else{
      new SuppliesRepository().getProviderSupplies(providerName, success);
    }
  }
}

export function confirmSupply(supplyId){
  return (dispatch) => {
    dispatch({
      type: CONFIRM_SUPPLY_REQUEST,
      payload: {}
    })

    new OperationsRepository().confirmSupply(supplyId, () =>{
      getSupplies()(dispatch)
      dispatch({
        type: CONFIRM_SUPPLY_SUCCESS,
        payload: {}
      })
    })
  }
}

export function returnSupply(supplyId){
  return (dispatch) => {
    dispatch({
      type: RETURN_SUPPLY_REQUEST,
      payload: {}
    })

    new OperationsRepository().returnSupply(supplyId, () =>{
      getSupplies()(dispatch)
      dispatch({
        type: RETURN_SUPPLY_SUCCESS,
        payload: {}
      })
    })
  }
}

export function addSupply(itemName, count, provider, employee, success){
  return (dispatch) => {
    dispatch({
      type: ADD_SUPPLY_REQUEST,
      payload: {}
    })

    new OperationsRepository().addSupply(itemName, count, provider, employee, () =>{
      getSupplies()(dispatch);
      success();
      dispatch({
        type: ADD_SUPPLY_SUCCESS,
        payload: {}
      });
    })
  }
}
