import {
  GET_NOTIFICATIONS_REQUEST,
  GET_NOTIFICATIONS_SUCCESS,
  GET_NOTIFICATIONS_FAILED,
} from '../../constants/notifications/notifications'


const initialState = {
  data: [],
  isFetching: false,
  errorMessage: null
}

export default function notifications(state = initialState, action) {
  switch (action.type) {

       case GET_NOTIFICATIONS_REQUEST:
         return Object.assign({}, state, {
           data: [],
           isFetching: true,
           errorMessage: null
         })

       case GET_NOTIFICATIONS_FAILED:
       return Object.assign({}, state, {
         data: [],
         isFetching: false,
         errorMessage: null
       })

       case GET_NOTIFICATIONS_SUCCESS:
         return Object.assign({}, state, {
           data: action.payload,
           isFetching: false,
           errorMessage: null
         })

       default:
         return state;
   }
}
