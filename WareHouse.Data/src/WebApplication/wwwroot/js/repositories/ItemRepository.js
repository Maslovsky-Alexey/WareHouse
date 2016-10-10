
var ServerMediator = require('./ServerMediator.js');

var ItemRepository = function() {
    serverMediator = new ServerMediator.ServerMediator();

    this.getItems = function (success) {
        serverMediator.sendRequest('api/items/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    };

    this.getPageItems = function (success, page) {
        serverMediator.sendRequest('api/items/GetPage/' + page, 'get', null, function (data) {

            success(JSON.parse(data));
        });
    };

    this.getPageItemsWithFilter = function (success, page, filter) {
        if (filter)
            serverMediator.sendRequest('api/items/GetPage/' + page + '/' + filter, 'get', null, function (data) {
                success(JSON.parse(data));
            });
        else
            serverMediator.sendRequest('api/items/GetPage/' + page, 'get', null, function (data) {
                success(JSON.parse(data));
            });
    };

    this.addItem = function (item, success) {
        serverMediator.sendRequest('api/items', 'post', JSON.stringify(item), success);
    };

    this.removeItem = function (item, success) {
        serverMediator.sendRequest('api/items/updatecount', 'post', JSON.stringify(item), success);
    };
};

exports.ItemRepository = ItemRepository;


