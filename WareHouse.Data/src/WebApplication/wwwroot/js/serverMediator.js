function getItems(success) {
    toServer('http://localhost:33649/api/items', 'get', null, function (data) {
        success(JSON.parse(data));
    });
}

function toServer(url, type, data, success) {
    var XHR = ("onload" in new XMLHttpRequest()) ? XMLHttpRequest : XDomainRequest;

    var xhr = new XHR();
    // (2) запрос на другой домен :)
    xhr.open(type, url, true);

    xhr.onload = function (a, b) {
        success(xhr.response);
    };

    xhr.onerror = function () {
        alert('Ошибка ' + this.status);
    };

    xhr.send();
}
