/// <reference path="servermediator.js" />
var CreateClientRepository = function() {
    this.serverMediator = new CreateServerMediator(),

    this.getClients = function (success) {
        this.serverMediator.sendRequest('http://localhost:33649/api/clients/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    },

    this.addClient = function (item, success) {
        this.serverMediator.sendRequest('http://localhost:33649/api/clients', 'post', JSON.stringify(item), success);
    }    
};




