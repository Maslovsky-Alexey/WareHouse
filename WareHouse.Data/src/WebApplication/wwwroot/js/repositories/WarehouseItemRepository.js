/// <reference path="servermediator.js" />
var WarehouseItemsRepository = function () {
    this.serverMediator = new ServerMediator(),

    this.getItems = function (success) {
        this.serverMediator.sendRequest('api/warehouseitems/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    },

    this.addOrder = function (item, success) {
        this.serverMediator.sendRequest('api/warehouseitems/addorder', 'post', JSON.stringify(item), success);
    }

    this.addSupply = function (item, success) {
        this.serverMediator.sendRequest('api/warehouseitems/addsupply', 'post', JSON.stringify(item), success);
    }
};




