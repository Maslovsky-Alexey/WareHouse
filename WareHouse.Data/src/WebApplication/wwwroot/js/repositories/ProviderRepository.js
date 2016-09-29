/// <reference path="servermediator.js" />
var ProviderRepository = function() {
    this.serverMediator = new ServerMediator(),

    this.getProviders = function (success) {
        this.serverMediator.sendRequest('api/providers/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    },

    this.addProvder = function (item, success) {
        this.serverMediator.sendRequest('api/providers', 'post', JSON.stringify(item), success);
    }
};













