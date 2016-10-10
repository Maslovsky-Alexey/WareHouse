/// <reference path="servermediator.js" />
var ServerMediator = require('./ServerMediator.js');


var WarehouseItemsRepository = function () {
    serverMediator = new ServerMediator.ServerMediator(),

    this.getItems = function (success) {
        serverMediator.sendRequest('api/warehouseitems/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    };
};


exports.WarehouseItemsRepository = WarehouseItemsRepository;

