import {
  GET_USER_INFORMATION_REQUEST,
  GET_USER_INFORMATION_SUCCESS,
  GET_USER_INFORMATION_FAILED
} from '../../constants/profile/about'

const initialState = {
  name: "noname",
  nickname: "noname",
  isEmployee: false,
  errorMessage: null
}

export default function about(state = initialState, action) {
  switch (action.type) {
   case GET_USER_INFORMATION_REQUEST:
     return Object.assign({}, state, {
       errorMessage: null
     })

   case GET_USER_INFORMATION_SUCCESS:
    console.debug(action.payload.id)
     return Object.assign({}, state, {
       name: action.payload.name,
       nickname: action.payload.login,
       isEmployee: action.payload.isEmployee,
       errorMessage: null
     })

    case GET_USER_INFORMATION_FAILED:
      return Object.assign({}, state, {
        nickname: null,
        errorMessage: action.payload.errorMessage
      })

     default:
       return state;
   }
}
