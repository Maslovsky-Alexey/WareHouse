/// <reference path="servermediator.js" />
var OperationRepository = function () {
    this.serverMediator = new ServerMediator(),


    this.addOrder = function (item, success) {
        this.serverMediator.sendRequest('api/operations/addorder', 'post', JSON.stringify(item), success);
    }

    this.addSupply = function (item, success) {
        this.serverMediator.sendRequest('api/operations/addsupply', 'post', JSON.stringify(item), success);
    }
};




