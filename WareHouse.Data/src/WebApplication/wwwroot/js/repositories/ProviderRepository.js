var ServerMediator = require("./ServerMediator.js");

var ProviderRepository = function() {
    serverMediator = new ServerMediator.ServerMediator(),
        this.getProviders = function(success) {
            serverMediator.sendRequest("api/providers/",
                "get",
                null,
                function(data) {
                    success(JSON.parse(data));
                });
        },
        this.addProvder = function(item, success) {
            serverMediator.sendRequest("api/providers", "post", JSON.stringify(item), success);
        };
};

exports.ProviderRepository = ProviderRepository;