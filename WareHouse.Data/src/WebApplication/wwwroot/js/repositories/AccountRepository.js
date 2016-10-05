/// <reference path="servermediator.js" />
var AccountRepository = function () {

    serverMediator = new ServerMediator(),

    this.registerClient = function (username, password, success) {
        var model = {
            username: username, password: password
        };

        serverMediator.sendRequest("api/account/registerclient", 'post', JSON.stringify(model), success);
    }

    this.registerEmployee = function (username, password, success) {
        var model = {
            username: username, password: password
        };

        serverMediator.sendRequest("api/account/registeremployee", 'post', JSON.stringify(model), success);
    }

    this.login = function (username, password, success) {
        var model = {
            username: username,
            password: password
        };

        serverMediator.sendRequest("api/account/login", 'post', JSON.stringify(model), success);
    }

    this.getCurrentUser = function (success) {
        serverMediator.sendRequest("api/account/getcurrentuser", 'get', null, success);
    }
};




