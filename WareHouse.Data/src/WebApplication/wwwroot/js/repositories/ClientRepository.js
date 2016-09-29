/// <reference path="servermediator.js" />
var CreateClientRepository = function () {
    //TODO: Странно выглядит конструкция new Create..., скорее должно быть существительное, как название класса. Нужно почитать про ООП в JS.
    this.serverMediator = new CreateServerMediator(),

    this.getClients = function (success) {
        //TODO: адрес хоста нужно инкапсулировать в конфигурацию, чтобы он встречался только в одном месте.
        this.serverMediator.sendRequest('http://localhost:33649/api/clients/', 'get', null, function (data) {
            success(JSON.parse(data));
        });
    },

    this.addClient = function (item, success) {
        this.serverMediator.sendRequest('http://localhost:33649/api/clients', 'post', JSON.stringify(item), success);
    }    
};




