/// <reference path="servermediator.js" />
var CreateItemStatusesRepository = function() {
    this.serverMediator = new CreateServerMediator(),

    this.getStatuses = function (success) {
        this.serverMediator.sendRequest('http://localhost:33649/api/itemstatuses/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    }
};




