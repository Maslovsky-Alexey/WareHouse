
var ServerMediator = require("./ServerMediator.js");

var SupplyRepository = function() {
    serverMediator = new ServerMediator.ServerMediator();

    this.getSupplies = function(success) {
        serverMediator.sendRequest("api/supplies/", "get", null,
            (data) => success(JSON.parse(data)));
    };

    this.getProviderSupplies = function (providerName, success) {
        serverMediator.sendRequest("api/supplies/" + providerName, "get", null,
            (data) => success(JSON.parse(data)));
    };
};

exports.SupplyRepository = SupplyRepository;