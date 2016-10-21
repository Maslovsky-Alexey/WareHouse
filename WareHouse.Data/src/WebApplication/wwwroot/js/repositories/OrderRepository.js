
var ServerMediator = require("./ServerMediator.js");

var OrderRepository = function() {
    serverMediator = new ServerMediator.ServerMediator();

    this.getOrders = function(success) {
        serverMediator.sendRequest("api/orders/", "get", null,
            (data) => success(JSON.parse(data)));
    };

    this.getClientOrders = function (clientName, success) {
        serverMediator.sendRequest("api/orders/GetClientOrders/" + clientName, "get", null,
            (data) => success(JSON.parse(data)));
    };
};

exports.OrderRepository = OrderRepository;