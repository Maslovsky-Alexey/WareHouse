/// <reference path="servermediator.js" />
var ItemStatusesRepository = function() {
    this.serverMediator = new ServerMediator(),

    this.getStatuses = function (success) {
        this.serverMediator.sendRequest('api/itemstatuses/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    }
};




