"use strict";

/// <reference path="../../repositories/accountrepository.js" />

var ProfileView = React.createClass({
    displayName: "ProfileView",

    accountRepository: new AccountRepository(),
    isInvalidUser: true,

    getInitialState: function getInitialState() {
        this.accountRepository.getCurrentUser(this.onGetedUser);

        return { profile: {} };
    },

    onGetedUser: function onGetedUser(user) {
        if (user == null)    
            return;
        
        this.isInvalidUser = false;
        console.debug(JSON.stringify(user));
        this.setState({ profile: user });
    },

    render: function render() {
        if (this.isInvalidUser) return React.createElement(
            "div",
            null,
            "Error"
        );
        return React.createElement(
            "div",
            { className: "row" },
            React.createElement(
                "div",
                { className: "col-xs-3" },
                "Login: ",
                this.state.profile.login
            ),
            React.createElement(
                "div",
                { className: "col-xs-6" },
                "Name: ",
                this.state.profile.name
            ),
            React.createElement(
                "div",
                { className: "col-xs-3" },
                this.state.profile.isEmployee ? "Employee" : "Client"
            )
        );
    }
});

ReactDOM.render(React.createElement(ProfileView, null), document.getElementById('root'));