import URI from 'urijs'

export default class AuthAPI{
  uri = "http://localhost:11492/"

  login(){
    let uri = window.location.href.split('?')[0]
    window.location.replace(this.uri + "?redirect_uri=" + uri)
  }
}
