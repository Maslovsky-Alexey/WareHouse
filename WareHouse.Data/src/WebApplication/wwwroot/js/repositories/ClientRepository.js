/// <reference path="servermediator.js" />
var ClientRepository = function () {

    this.serverMediator = new ServerMediator(),

    this.getClients = function (success) {
        this.serverMediator.sendRequest('api/clients/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    },

    this.addClient = function (item, success) {
        this.serverMediator.sendRequest('api/clients', 'post', JSON.stringify(item), success);
    }    
};




