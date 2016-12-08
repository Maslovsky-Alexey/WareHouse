import {
  GET_NOTIFICATIONS_REQUEST,
  GET_NOTIFICATIONS_SUCCESS,
  GET_NOTIFICATIONS_FAILED,
} from '../../constants/notifications/notifications'

import NotificationsRepository from '../../repositories/NotificationsRepository'

export function getNotifications(ticks) {

  return (dispatch) => {
    dispatch({
      type: GET_NOTIFICATIONS_REQUEST,
      payload: {}
    })

    new NotificationsRepository().getNotifications(ticks, (data) => {

      if (data == null || data.length == 0){
        dispatch({
          type: GET_NOTIFICATIONS_FAILED,
          payload: {}
        })
      }
      else{
        dispatch({
          type: GET_NOTIFICATIONS_SUCCESS,
          payload: data
        })
      }
    })
  }
}
