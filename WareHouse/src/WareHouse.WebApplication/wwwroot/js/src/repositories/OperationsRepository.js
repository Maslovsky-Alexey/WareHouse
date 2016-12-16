import ServerMediator from './ServerMediator'

export default class OperationsRepository extends ServerMediator{
  addOrder(itemName, count, client, employee, success) {
      let model = {
        item: {
          id: itemName
        },

        employee: {
          name: employee
        },

        client: {
          id: client
        },

        count: count
      }

      super.sendRequest("api/operations/orders", "post", JSON.stringify(model), success);
  }

  addSupply(itemName, count, provider, employee, success) {

      let model = {
        item: {
          id: itemName
        },

        provider: {
          id: provider
        },

        employee: {
          name: employee
        },

        count: count
      }

      super.sendRequest("api/operations/supplies", "post", JSON.stringify(model), success);
  }

  addItemWithoutRepetition(item, desc, b64, success) {
      const model = {
        name: item,
        description: desc,
        base64: b64.substring(b64.indexOf('base64,') + 7) // временный костыль
      }
      super.sendRequest("api/operations/items", "post", JSON.stringify(model), success);
  }

  confirmOrder(id, success) {
      super.sendRequest("api/operations/orders/actions/confirm/" + id, "post", null, success);
  }

  confirmSupply(id, success) {
      super.sendRequest("api/operations/supplies/actions/confirm/" + id, "post", null, success);
  }

  returnOrder(id, success) {
      super.sendRequest("api/operations/orders/actions/return/" + id, "post", null, success);
  }

  returnSupply(id, success) {
      super.sendRequest("api/operations/supplies/actions/return/" + id, "post", null, success);
  }
}
