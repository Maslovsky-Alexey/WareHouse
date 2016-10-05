/// <reference path="servermediator.js" />
var ClientRepository = function () {

    serverMediator = new ServerMediator(),

    this.getClients = function (success) {
        serverMediator.sendRequest('api/clients/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    },

    this.addClient = function (item, success) {
        serverMediator.sendRequest('api/clients', 'post', JSON.stringify(item), success);
    }    
};




