var Dispatcher = require('../dispatcher/dispatcher.js').Dispatcher;
var ClientRepository = require('../repositories/clientrepository.js').ClientRepository;

var clients = [];
var clientRepository = new ClientRepository();
var onChangeListeners = [];

clientRepository.getClients((data) => {
    clients = data;
    onChangeListeners.forEach((callback) => callback(clients));
});

function addClient(client) {
    clientRepository.addProvder(client, function () {
        clientRepository.getClients(function (data) {
            clients = data;

            onChangeListeners.forEach((callback) => callback(clients));
        });
    });
};


var ClientStore = {
    addOnChangeListener: function(callback){
        onChangeListeners.push(callback);
    },

    getClients: function () {
        return clients;
    }
};

Dispatcher.register(function (payload) {
    if (payload.name == 'add-client') {
        addClient(payload.data);
    }    
});


exports.ClientStore = ClientStore;