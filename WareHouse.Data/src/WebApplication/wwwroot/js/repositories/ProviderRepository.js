/// <reference path="servermediator.js" />
var CreateProviderRepository = function() {
    this.serverMediator = new CreateServerMediator(),

    this.getProviders = function (success) {
        this.serverMediator.sendRequest('http://localhost:33649/api/providers/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    },

    this.addProvder = function (item, success) {
        this.serverMediator.sendRequest('http://localhost:33649/api/providers', 'post', JSON.stringify(item), success);
    }
};













