var ServerMediator = function() {
    this.host = "http://localhost:11492/";

    var sendReq = function (url, type, data, success) {
        var XHR = ("onload" in new XMLHttpRequest()) ? XMLHttpRequest : XDomainRequest;

        var xhr = new XHR();

        xhr.open(type, url, true);

        xhr.setRequestHeader("Content-Type", "application/json; charset=UTF-8");
        xhr.setRequestHeader("Accept", "application/json");

        xhr.onload = function (a, b) {
            success(xhr.response, xhr);
        };

        xhr.send(data);
    };

    this.sendRequest = function(url, type, data, success) {
        sendReq(this.host + url, type, data, success);
    };

    this.sendAnotherRequest = function (url, type, data, success) {
        window.location.href = url;
    };
};

exports.ServerMediator = ServerMediator;