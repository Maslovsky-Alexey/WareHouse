function getItems(success) {
    toServer('http://localhost:33649/api/items', 'get', null, function (data) {
        success(JSON.parse(data));
    });
}

function addItem(item, success) {
    toServer('http://localhost:33649/api/items', 'post', JSON.stringify(item), success);
}

function removeItem(item, success) {
    toServer('http://localhost:33649/api/items/updatecount', 'post', JSON.stringify(item), success);
}

function toServer(url, type, data, success) {
    var XHR = ("onload" in new XMLHttpRequest()) ? XMLHttpRequest : XDomainRequest;

    var xhr = new XHR();

    xhr.open(type, url, true);

       
    xhr.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');

    xhr.onload = function (a, b) {
        success(xhr.response);
    };

    xhr.send(data);
}
