var ServerMediator = require('./ServerMediator.js');

var OperationRepository = function () {
    serverMediator = new ServerMediator.ServerMediator(),


    this.addOrder = function (item, success) {
        serverMediator.sendRequest('api/operations/addorder', 'post', JSON.stringify(item), success);
    }

    this.addSupply = function (item, success) {
        serverMediator.sendRequest('api/operations/addsupply', 'post', JSON.stringify(item), success);
    }
};

exports.OperationRepository = OperationRepository;

