import ServerMediator from './ServerMediator'

export default class NotificationsRepository extends ServerMediator{
  getNotifications(ticks, success) {
      super.sendRequest("api/notifications/" + ticks,
          "get",
          null,
          function(data) {
              success(JSON.parse(data));
          })
  }
}
