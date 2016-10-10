"use strict";

/// <reference path="../../repositories/accountrepository.js" />

var LoginView = React.createClass({
    displayName: "LoginView",

    accountRepository: new AccountRepository(),

    Send: function Send() {
        var name = $("#username1").val();
        var password = $("#password1").val();

        this.accountRepository.login(name, password, this.loginSuccess);
    },

    loginSuccess: function loginSuccess(isSuccess) {
        isSuccess = isSuccess == "true";
        console.debug(isSuccess);
        if (isSuccess == true) alert("YAHOOO!"); else alert("OOOPPS :( "); //TODO: измменить на нормальное отображение
    },

    render: function render() {

        return React.createElement(
            "div",
            { className: "login-form" },
            React.createElement(
                "div",
                { className: "form-group" },
                React.createElement(
                    "label",
                    { htmlFor: "username1" },
                    "Username"
                ),
                React.createElement("input", { className: "form-control", id: "username1", placeholder: "Username" })
            ),
            React.createElement(
                "div",
                { className: "form-group" },
                React.createElement(
                    "label",
                    { htmlFor: "password1" },
                    "Password"
                ),
                React.createElement("input", { type: "password", className: "form-control", id: "password1", placeholder: "Password" })
            ),
            React.createElement(
                "button",
                { type: "submit", className: "btn btn-default", onClick: this.Send },
                "Submit"
            )
        );
    }
});

ReactDOM.render(React.createElement(LoginView, null), document.getElementById('root'));