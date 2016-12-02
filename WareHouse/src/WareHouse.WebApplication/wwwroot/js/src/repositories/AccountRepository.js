import ServerMediator from './ServerMediator'

export default class AccountRepository extends ServerMediator{

    registerClient(username, password, success) {
        let model = {
            username: username,
            password: password
        }

        super.sendRequest("api/account/clients/actions/register", "post", JSON.stringify(model), success)
    }

    registerEmployee(username, password, success) {
        let model = {
            username: username,
            password: password
        }

        super.sendRequest("api/account/employees/actions/register", "post", JSON.stringify(model), success);
    };

    login(username, password, success) {
        let model = {
            username: username,
            password: password
        }

        super.sendRequest("api/account/login",
            "post",
            JSON.stringify(model),
            function(isSuccess, httpContext) {
                if (isSuccess == "true") {
                    var token = httpContext.getResponseHeader("Authorization")
                    window.localStorage.setItem("AuthToken", token)
                }

                success(isSuccess);
            });
    };

    getCurrentUser(success) {
        super.sendRequest("api/account/currentuser",
            "get",
            null,
            function(data) {
                if (data == "")
                    data = "null";

                success(JSON.parse(data));
            });
    };
    getUserByName(username, success) {

        super.sendRequest("api/account/users/" + username,
            "get",
            null,
            function(data) {
                if (data == "")
                    data = "null";

                success(JSON.parse(data));
            });
    };

    _addRole(username, role, success) {
        super.sendRequest("api/account/users/" + username + "/roles/?role=" + role,
            "post",
            null,
            function (data) {
                if (data == "")
                    data = "null";

                success(JSON.parse(data));
            });
    };

    addEmployeeRole (username, success) {
        this._addRole(username, 'employee', success);
    };

    addClientRole (username, success) {
        this._addRole(username, 'client', success);
    };
};
