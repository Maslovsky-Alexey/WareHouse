var ServerMediator = require("./ServerMediator.js");

var OperationRepository = function() {
    serverMediator = new ServerMediator.ServerMediator(),
    this.addOrder = function(item, success) {
        serverMediator.sendRequest("api/operations/orders", "post", JSON.stringify(item), success);
    };
    this.addSupply = function(item, success) {
        serverMediator.sendRequest("api/operations/supplies", "post", JSON.stringify(item), success);
    };
    this.addItemWithoutRepetition = function(item, success) {
        serverMediator.sendRequest("api/operations/items", "post", JSON.stringify(item), success);
    };

    this.confirmOrder = function (id, success) {
        serverMediator.sendRequest("api/operations/orders/actions/confirm/" + id, "put", null, success);
    };

    this.confirmSupply = function (id, success) {
        serverMediator.sendRequest("api/operations/supplies/actions/confirm/" + id, "put", null, success);
    };

    this.returnOrder = function (id, success) {
        serverMediator.sendRequest("api/operations/orders/actions/return/" + id, "put", null, success);
    };

    this.returnSupply = function (id, success) {
        serverMediator.sendRequest("api/operations/supplies/actions/return/" + id, "put", null, success);
    };
};

exports.OperationRepository = OperationRepository;