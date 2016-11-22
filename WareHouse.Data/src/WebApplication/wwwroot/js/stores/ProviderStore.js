var Dispatcher = require("../dispatcher/dispatcher.js").Dispatcher;
var ProviderRepository = require("../repositories/providerrepository.js").ProviderRepository;

var providers = [];
var providerRepository = new ProviderRepository();
var onChangeListeners = [];

providerRepository.getProviders((data) => {
    providers = data;
    onChangeListeners.forEach((callback) => callback(providers));
});

function addProvder(provider) {
    providerRepository.addProvder(provider,
        function() {
            providerRepository.getProviders(function(data) {
                providers = data;

                onChangeListeners.forEach((callback) => callback(providers));
            });
        });
};


var ProviderStore = {
    addOnChangeListener: function(callback) {
        onChangeListeners.push(callback);
    },

    getProviders: function() {
        return providers;
    }
};

Dispatcher.register(function(payload) {
    if (payload.name == "add-provider") {
        addProvder(payload.data);
    }
});


exports.ProviderStore = ProviderStore;