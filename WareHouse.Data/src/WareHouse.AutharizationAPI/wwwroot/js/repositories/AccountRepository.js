var ServerMediator = require("./ServerMediator.js");

var AccountRepository = function() {

    serverMediator = new ServerMediator.ServerMediator(),

    this.login = function(username, password, success) {
        var model = {
            username: username,
            password: password
        };

        serverMediator.sendRequest("api/account/login",
            "post",
            JSON.stringify(model),
            function (data, httpContext) {
                var token = null;

                if (data != "null") {
                    token = httpContext.getResponseHeader("Authorization");                   
                }

                success(token);
            });
    };
};

exports.AccountRepository = AccountRepository;