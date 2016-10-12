
var ServerMediator = require('./ServerMediator.js');

var ItemRepository = function() {
    serverMediator = new ServerMediator.ServerMediator();

    this.getItems = function (success) {
        serverMediator.sendRequest('api/items/', 'get', null, function (data) {
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


