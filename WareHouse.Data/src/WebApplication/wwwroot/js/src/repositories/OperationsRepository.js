import ServerMediator from './ServerMediator'

export default class OperationsRepository extends ServerMediator{
  addOrder(item, success) {
      super.sendRequest("api/operations/orders", "post", JSON.stringify(item), success);
  };
  addSupply(item, success) {
      super.sendRequest("api/operations/supplies", "post", JSON.stringify(item), success);
  };
  addItemWithoutRepetition(item, success) {
      super.sendRequest("api/operations/items", "post", JSON.stringify(item), success);
  };

  confirmOrder(id, success) {
      super.sendRequest("api/operations/orders/actions/confirm/" + id, "put", null, success);
  };

  confirmSupply(id, success) {
      super.sendRequest("api/operations/supplies/actions/confirm/" + id, "put", null, success);
  };

  returnOrder(id, success) {
      super.sendRequest("api/operations/orders/actions/return/" + id, "put", null, success);
  };

  returnSupply(id, success) {
      super.sendRequest("api/operations/supplies/actions/return/" + id, "put", null, success);
  };
};
