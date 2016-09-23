/// <reference path="../servermediator.js" />

var CreateItemRepository = function() {
    this.serverMediator = new CreateServerMediator();

    this.getItems = function (success) {
        this.serverMediator.sendRequest('http://localhost:33649/api/items/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    };

    this.getPageItems = function (success, page) {
        this.serverMediator.sendRequest('http://localhost:33649/api/items/GetPage/' + page + '/?$property1=count&$morethan1=9&$lessthan1=21', 'get', null, function (data) {

            success(JSON.parse(data));
        });
    };

    this.addItem = function (item, success) {
        this.serverMediator.sendRequest('http://localhost:33649/api/items', 'post', JSON.stringify(item), success);
    };

    this.removeItem = function (item, success) {
        this.serverMediator.sendRequest('http://localhost:33649/api/items/updatecount', 'post', JSON.stringify(item), success);
    };
};


