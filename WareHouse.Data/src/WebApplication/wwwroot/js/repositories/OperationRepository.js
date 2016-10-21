var ServerMediator = require("./ServerMediator.js");

var OperationRepository = function() {
    serverMediator = new ServerMediator.ServerMediator(),
    this.addOrder = function(item, success) {
        serverMediator.sendRequest("api/operations/addorder", "post", JSON.stringify(item), success);
    };
    this.addSupply = function(item, success) {
        serverMediator.sendRequest("api/operations/addsupply", "post", JSON.stringify(item), success);
    };
    this.addItemWithoutRepetition = function(item, success) {
        serverMediator.sendRequest("api/operations/AddItemWithoutRepetition", "post", JSON.stringify(item), success);
    };

    this.confirmOrder = function (id, success) {
        serverMediator.sendRequest("api/operations/confirmorder/" + id, "put", null, success);
    };

    this.confirmSupply = function (id, success) {
        serverMediator.sendRequest("api/operations/ConfirmSupply/" + id, "put", null, success);
    };

    this.returnOrder = function (id, success) {
        serverMediator.sendRequest("api/operations/ReturnOrder/" + id, "put", null, success);
    };

    this.returnSupply = function (id, success) {
        serverMediator.sendRequest("api/operations/ReturnSupply/" + id, "put", null, success);
    };
};

exports.OperationRepository = OperationRepository;