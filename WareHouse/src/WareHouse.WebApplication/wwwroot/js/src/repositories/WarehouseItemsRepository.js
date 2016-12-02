import ServerMediator from './ServerMediator'

export default class WarehouseItemsRepository extends ServerMediator{

  getItems(success) {
      super.sendRequest("api/warehouseitems/",
          "get",
          null,
          function(data) {
              success(JSON.parse(data));
          });
  }

  getPageItems(success, page) {
    super.sendRequest("api/warehouseitems/pages/?page=" + page,
        "get",
        null,
        function(data) {
            if (data === "")
                data = "null";

            success(JSON.parse(data));
        });
  };

  getPageItemsWithFilter(success, page, filter) {
    if (filter){
      super.sendRequest("api/warehouseitems/pages/?page=" + page + "&" + filter,
          "get",
          null,
          function(data) {
              if (data === "")
                  data = "null";

              success(JSON.parse(data));
          });
    }
    else{
      super.sendRequest("api/warehouseitems/pages/?page=" + page,
          "get",
          null,
          function(data) {
              success(JSON.parse(data));
          });
    }
  };

  getItemById(id, success) {
    super.sendRequest("api/warehouseitems/items/" + id,
        "get",
        null,
        function(data) {
            if (data === "")
                data = "null";

            success(JSON.parse(data));
        });
  };
};
