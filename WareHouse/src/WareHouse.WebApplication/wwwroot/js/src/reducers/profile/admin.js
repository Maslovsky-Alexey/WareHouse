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

const initialState = {
  clients: [],
  providers: [],
  errorMessage: null
}

export default function admin(state = initialState, action) {
  switch (action.type) {

   case ADD_EMPLOYEE_REQUEST:
   case ADD_CLIENT_REQUEST:
   case GET_PROVIDERS_REQUEST:
   case GET_CLIENTS_REQUEST:
   case ADD_PROVIDER_REQUEST:
     return Object.assign({}, state, {
       errorMessage: null
     })

   case ADD_EMPLOYEE_SUCCESS:
   case ADD_PROVIDER_SUCCESS:
   case ADD_CLIENT_SUCCESS:
     return Object.assign({}, state, {
       errorMessage: null
     })

    case ADD_EMPLOYEE_FAILED:
    case ADD_CLIENT_FAILED:
    case GET_PROVIDERS_FAILED:
    case GET_CLIENTS_FAILED:
      return Object.assign({}, state, {
        errorMessage: action.payload.errorMessage
      })


   case GET_CLIENTS_SUCCESS:
     return Object.assign({}, state, {
       clients: action.payload
     })

   case GET_PROVIDERS_SUCCESS:
     return Object.assign({}, state, {
       providers: action.payload
     })

   default:
     return state;
   }
}
