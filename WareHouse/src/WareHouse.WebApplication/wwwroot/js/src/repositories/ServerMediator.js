export default class ServerMediator{
  host = "http://localhost:33649/"

  sendRequest(url, type, data, success){
    url = this.host + url

    const XHR = ("onload" in new XMLHttpRequest()) ? XMLHttpRequest : XDomainRequest

    const xhr = new XHR()

    xhr.open(type, url, true)

    xhr.setRequestHeader("Content-Type", "application/json; charset=UTF-8")
    xhr.setRequestHeader("Accept", "application/json")

    if (window.localStorage.getItem("AuthToken") != null){
          xhr.setRequestHeader("Authorization", window.localStorage.getItem("AuthToken"))
    }

    xhr.onload = function(a, b) {
        success(xhr.response, xhr)
    }

    xhr.send(data)
  }
}
