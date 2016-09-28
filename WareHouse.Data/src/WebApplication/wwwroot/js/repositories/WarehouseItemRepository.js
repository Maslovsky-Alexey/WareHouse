/// <reference path="servermediator.js" />
var CreateWarehouseItemsRepository = function () {
    this.serverMediator = new CreateServerMediator(),

    this.getItems = function (success) {
        this.serverMediator.sendRequest('http://localhost:33649/api/warehouseitems/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    },

    this.addOrder = function (item, success) {
        this.serverMediator.sendRequest('http://localhost:33649/api/warehouseitems/addorder', 'post', JSON.stringify(item), success);
    }

    this.addSupply = function (item, success) {
        this.serverMediator.sendRequest('http://localhost:33649/api/warehouseitems/addsupply', 'post', JSON.stringify(item), success);
    }
};




