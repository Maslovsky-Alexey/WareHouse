/// <reference path="servermediator.js" />
var ItemStatusesRepository = function() {
    serverMediator = new ServerMediator(),

    this.getStatuses = function (success) {
        serverMediator.sendRequest('api/itemstatuses/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    }
};




