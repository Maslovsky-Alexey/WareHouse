var ServerMediator = require("./ServerMediator.js");

var AccountRepository = function() {

    serverMediator = new ServerMediator.ServerMediator(),
        this.registerClient = function(username, password, success) {
            var model = {
                username: username,
                password: password
            };

            serverMediator.sendRequest("api/account/registerclient", "post", JSON.stringify(model), success);
        };
    this.registerEmployee = function(username, password, success) {
        var model = {
            username: username,
            password: password
        };

        serverMediator.sendRequest("api/account/registeremployee", "post", JSON.stringify(model), success);
    };
    this.login = function(username, password, success) {
        var model = {
            username: username,
            password: password
        };

        serverMediator.sendRequest("api/account/login",
            "post",
            JSON.stringify(model),
            function(isSuccess, httpContext) {
                if (isSuccess == "true") {
                    var token = httpContext.getResponseHeader("Authorization");
                    window.localStorage.setItem("AuthToken", token);
                }

                success(isSuccess);
            });
    };
    this.getCurrentUser = function(success) {
        serverMediator.sendRequest("api/account/getcurrentuser",
            "get",
            null,
            function(data) {
                if (data == "")
                    data = "null";

                success(JSON.parse(data));
            });
    };
    this.getUserByName = function(username, success) {

        serverMediator.sendRequest("api/account/getuserbyname/" + username,
            "get",
            null,
            function(data) {
                if (data == "")
                    data = "null";

                success(JSON.parse(data));
            });
    };
};

exports.AccountRepository = AccountRepository;