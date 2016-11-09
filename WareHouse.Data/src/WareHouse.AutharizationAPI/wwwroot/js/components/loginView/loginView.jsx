var React = require("react");
var ReactDom = require("react-dom");

var GenerateRedirectUri = require("../../helps/uriqueryhelper.js").GenerateRedirectUri;
var AccountRepository = require("../../repositories/accountrepository.js").AccountRepository;
var ErrorView = require("../../errorview/errorview.js").ErrorView;

var LoginView = React.createClass({

    getInitialState: function () {
        return { name: "", password: "" };
    },

    Login: function () {
        if (!this.isValidValues()) {
            new ErrorView().error('Shaytan');
            return;
        }

        new AccountRepository().login(this.state.name, this.state.password, this.successLogin);      
    },

    Register: function () {
        if (!this.isValidValues()) {
            new ErrorView().error('Shaytan');
            return;
        }

        new AccountRepository().register(this.state.name, this.state.password, this.successLogin);
    },

    successLogin: function (token) {
        if (!token) {
            new ErrorView().error('Shaytan');
            return;
        }

        var redirectUri = GenerateRedirectUri(token);

        if (redirectUri)
            window.location.replace(redirectUri);
    },

    isValidValues: function(){
        return this.state.name && this.state.password;
    },

    nameChanged: function (e) {
        this.setState({ name: e.target.value, password: this.state.password });
    },

    passwordChanged: function (e) {
        this.setState({ name: this.state.name, password: e.target.value });
    },

    render: function () {
        return (
            <div className="login-form row">
                <div className="col-sm-4 col-sm-offset-4">
                    <div className="form-group">
                        <label htmlFor="username1">Username</label>
                        <input className="form-control" id="username1" placeholder="Username" onChange={this.nameChanged}/>
                    </div>
                    <div className="form-group">
                        <label htmlFor="password1">Password</label>
                        <input type="password" className="form-control" id="password1" placeholder="Password" onChange={this.passwordChanged}/>
                    </div>
                    <div className="row">
                        <div className="col-sm-1">
                            <button type="submit" className="btn btn-success" onClick={this.Login}>Login</button>
                        </div>
                        <div className="col-sm-1 col-sm-offset-1">
                            <button type="submit" className="btn btn-success" onClick={this.Register}>Register</button>
                        </div>
                        <div className="col-sm-1 col-sm-offset-1">
                            <button type="submit" className="btn btn-default" onClick={this.Send}>Vk</button>
                        </div>
                        <div className="col-sm-1 col-sm-offset-1">
                            <button type="submit" className="btn btn-default" onClick={this.Send}>Facebook</button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
});

exports.LoginView = LoginView;

