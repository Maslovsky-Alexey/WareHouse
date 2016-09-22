var CreateServerMediator = function () {
    this.sendRequest = function (url, type, data, success) {
        var XHR = ("onload" in new XMLHttpRequest()) ? XMLHttpRequest : XDomainRequest;

        var xhr = new XHR();

        xhr.open(type, url, true);

        xhr.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');

        xhr.setRequestHeader('Accept', 'application/json');
        xhr.setRequestHeader('Accept-Charset', 'utf-8');

        xhr.onload = function (a, b) {
            success(xhr.response);
        };

        xhr.send(data);
    }
};


