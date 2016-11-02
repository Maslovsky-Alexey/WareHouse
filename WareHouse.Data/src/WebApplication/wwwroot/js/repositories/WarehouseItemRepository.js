/// <reference path="servermediator.js" />
var ServerMediator = require("./ServerMediator.js");


var WarehouseItemsRepository = function() {
    serverMediator = new ServerMediator.ServerMediator(),
        this.getItems = function(success) {
            serverMediator.sendRequest("api/warehouseitems/",
                "get",
                null,
                function(data) {
                    success(JSON.parse(data));
                });
        };

    this.getPageItems = function(success, page) {
        serverMediator.sendRequest("api/warehouseitems/GetPage/?page=" + page,
            "get",
            null,
            function(data) {
                if (data === "")
                    data = "null";

                success(JSON.parse(data));
            });
    };

    this.getPageItemsWithFilter = function(success, page, filter) {
        console.debug(filter);
        if (filter)
            serverMediator.sendRequest("api/warehouseitems/GetPage/?page=" + page + "&" + filter,
                "get",
                null,
                function(data) {
                    if (data === "")
                        data = "null";

                    success(JSON.parse(data));
                });
        else
            serverMediator.sendRequest("api/warehouseitems/GetPage/?page=" + page,
                "get",
                null,
                function(data) {
                    success(JSON.parse(data));
                });
    };

    this.getItemById = function(id, success) {
        serverMediator.sendRequest("api/warehouseitems/GetItemById/" + id,
            "get",
            null,
            function(data) {
                if (data === "")
                    data = "null";

                success(JSON.parse(data));
            });
    };
};


exports.WarehouseItemsRepository = WarehouseItemsRepository;