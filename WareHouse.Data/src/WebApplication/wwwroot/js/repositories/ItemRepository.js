/// <reference path="../servermediator.js" />

var ItemRepository = function() {
    this.serverMediator = new ServerMediator();

    this.getItems = function (success) {
        this.serverMediator.sendRequest('api/items/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    };

    this.getPageItems = function (success, page) {
        this.serverMediator.sendRequest('api/items/GetPage/' + page, 'get', null, function (data) {

            success(JSON.parse(data));
        });
    };

    this.getPageItemsWithFilter = function (success, page, filter) {
        if (filter)
            this.serverMediator.sendRequest('api/items/GetPage/' + page + '/' + filter, 'get', null, function (data) {
                success(JSON.parse(data));
            });
        else
            this.serverMediator.sendRequest('api/items/GetPage/' + page, 'get', null, function (data) {
                success(JSON.parse(data));
            });
    };

    this.addItem = function (item, success) {
        this.serverMediator.sendRequest('api/items', 'post', JSON.stringify(item), success);
    };

    this.removeItem = function (item, success) {
        this.serverMediator.sendRequest('api/items/updatecount', 'post', JSON.stringify(item), success);
    };
};


