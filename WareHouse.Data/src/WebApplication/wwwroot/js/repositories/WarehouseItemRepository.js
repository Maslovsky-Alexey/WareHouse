/// <reference path="servermediator.js" />
var WarehouseItemsRepository = function () {
    serverMediator = new ServerMediator(),

    this.getItems = function (success) {
        serverMediator.sendRequest('api/warehouseitems/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    };
};




