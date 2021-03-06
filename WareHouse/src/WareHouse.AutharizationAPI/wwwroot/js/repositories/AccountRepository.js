﻿var ServerMediator = require("./ServerMediator.js");

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

    this.loginAD = function (username, password, success) {
        var model = {
            username: username,
            password: password
        };

        serverMediator.sendRequest("api/account/login/activedirectory",
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

    this.register = function (username, password, success) {
        var model = {
            username: username,
            password: password
        };

        serverMediator.sendRequest("api/account/register",
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


    this.logVk = function (redirect) {
        serverMediator.sendRequest("api/account/login/vk?redirect_uri=" + redirect,
            "post",
            null
            ,
            function (redirectUri) {
                window.location.href = redirectUri;
            });
    };

    this.logFacebook = function (redirect) {
        serverMediator.sendRequest("api/account/login/facebook?redirect_uri=" + redirect,
            "post",
            null
            ,
            function (redirectUri) {
                window.location.href = redirectUri;
            });
    };
};

exports.AccountRepository = AccountRepository;