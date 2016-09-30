/// <reference path="servermediator.js" />
var WarehouseItemsRepository = function () {
    this.serverMediator = new ServerMediator(),

    this.getItems = function (success) {
        this.serverMediator.sendRequest('api/warehouseitems/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    };
};




