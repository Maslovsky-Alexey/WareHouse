var React = require("react");
var ReactDom = require("react-dom");

var AccountRepository = require("../../repositories/accountrepository.js");
var Redirecter = require("../../helpers/redirecter.js").Redirecter;
var AuthAPI = require("../../helpers/authapi.js").AuthAPI;

var LoginView = React.createClass({
    accountRepository: new AccountRepository.AccountRepository(),


    componentDidMount: function () {
        var token = this.getTokenFromUri();

        if (!token)
            return;

        window.localStorage.setItem("AuthToken", token);

        this.accountRepository.getCurrentUser(function (user) {
            console.debug(user);
            if (user != null)
                Redirecter.redirect("/items");
        });
    },

    getTokenFromUri: function(){
        return URI(window.location.href).search(true).token;
    },

    Send: function () {
        new AuthAPI().login();
    },

    render: function() {


        return (
            <div className="row login-form">
                <div className="col-sm-4 col-sm-offset-4">
                    <button type="submit" className="btn btn-default" onClick={this.Send}>Enter</button>
                </div>

            </div>
        );
    }
});

exports.LoginView = LoginView;