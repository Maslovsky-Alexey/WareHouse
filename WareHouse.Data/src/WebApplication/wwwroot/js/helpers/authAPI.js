var AuthAPI = function() {
    var uri = "http://localhost:11492/";

    this.login = function () {
        window.location.replace(uri + "?redirect_uri=" + URI(window.location.href).origin());
    };
};

exports.AuthAPI = AuthAPI;