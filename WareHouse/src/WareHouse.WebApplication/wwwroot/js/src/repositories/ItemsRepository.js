import ServerMediator from './ServerMediator'

export default class ItemsRepository extends ServerMediator{
  getItems(success) {
      super.sendRequest("api/items/",
          "get",
          null,
          function(data) {
              success(JSON.parse(data));
          })
  }
}
