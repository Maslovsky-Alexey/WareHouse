var ServerMediator = function() {
    this.host = "http://localhost:11492/";

    this.sendRequest = function(url, type, data, success) {
        url = this.host + url;

        var XHR = ("onload" in new XMLHttpRequest()) ? XMLHttpRequest : XDomainRequest;

        var xhr = new XHR();

        xhr.open(type, url, true);

        xhr.setRequestHeader("Content-Type", "application/json; charset=UTF-8");
        xhr.setRequestHeader("Accept", "application/json");

        xhr.onload = function(a, b) {
            success(xhr.response, xhr);
        };

        xhr.send(data);
    };
};

exports.ServerMediator = ServerMediator;