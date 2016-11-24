import {
  ADD_EMPLOYEE_REQUEST,
  ADD_EMPLOYEE_SUCCESS,
  ADD_EMPLOYEE_FAILED,

  ADD_CLIENT_REQUEST,
  ADD_CLIENT_SUCCESS,
  ADD_CLIENT_FAILED
} from  '../../constants/profile/admin'

const initialState = {
  errorMessage: null
}

export default function admin(state = initialState, action) {
  switch (action.type) {
   case ADD_EMPLOYEE_REQUEST:
     return Object.assign({}, state, {
       errorMessage: null
     })

   case ADD_EMPLOYEE_SUCCESS:
     return Object.assign({}, state, {
       errorMessage: null
     })

    case ADD_EMPLOYEE_FAILED:
      return Object.assign({}, state, {
        errorMessage: action.payload.errorMessage
      })

    case ADD_CLIENT_REQUEST:
      return Object.assign({}, state, {
        errorMessage: null
      })

    case ADD_CLIENT_SUCCESS:
      return Object.assign({}, state, {
        errorMessage: null
      })

     case ADD_CLIENT_FAILED:
       return Object.assign({}, state, {
         errorMessage: action.payload.errorMessage
       })

     default:
       return state;
   }
}
