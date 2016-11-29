import ServerMediator from './ServerMediator'

export default class OrdersRepository extends ServerMediator{
  getOrders(success) {
      super.sendRequest("api/orders/", "get", null,
          (data) => success(JSON.parse(data)));
  };

  getClientOrders(clientName, success) {
      super.sendRequest("api/orders/" + clientName, "get", null,
          (data) => success(JSON.parse(data)));
  };
};
