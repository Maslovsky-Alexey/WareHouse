/// <reference path="../servermediator.js" />

var CreateItemRepository = function() {
    this.serverMediator = new CreateServerMediator();

    this.getItems = function (success) {
        this.serverMediator.sendRequest('http://localhost:33649/api/items/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    };

    this.getPageItems = function (success, page) {
        this.serverMediator.sendRequest('http://localhost:33649/api/items/GetPage/' + page, 'get', null, function (data) {

            success(JSON.parse(data));
        });
    };

    this.getPageItemsWithFilter = function (success, page, filter) {
        if (filter)
            this.serverMediator.sendRequest('http://localhost:33649/api/items/GetPage/' + page + '/' + filter, 'get', null, function (data) {
                success(JSON.parse(data));
            });
        else
            this.serverMediator.sendRequest('http://localhost:33649/api/items/GetPage/' + page, 'get', null, function (data) {
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


