var ServerMediator = require("./ServerMediator.js");

var OperationRepository = function() {
    serverMediator = new ServerMediator.ServerMediator(),
    this.addOrder = function(item, success) {
        serverMediator.sendRequest("api/operations/order", "post", JSON.stringify(item), success);
    };
    this.addSupply = function(item, success) {
        serverMediator.sendRequest("api/operations/supply", "post", JSON.stringify(item), success);
    };
    this.addItemWithoutRepetition = function(item, success) {
        serverMediator.sendRequest("api/operations/item", "post", JSON.stringify(item), success);
    };

    this.confirmOrder = function (id, success) {
        serverMediator.sendRequest("api/operations/order/actions/confirm/" + id, "put", null, success);
    };

    this.confirmSupply = function (id, success) {
        serverMediator.sendRequest("api/operations/supply/actions/confirm/" + id, "put", null, success);
    };

    this.returnOrder = function (id, success) {
        serverMediator.sendRequest("api/operations/order/actions/return/" + id, "put", null, success);
    };

    this.returnSupply = function (id, success) {
        serverMediator.sendRequest("api/operations/supply/actions/return/" + id, "put", null, success);
    };
};

exports.OperationRepository = OperationRepository;