
var React = require('react');
var ReactDom = require('react-dom');

var AccountRepository = require('../../repositories/accountrepository.js');

var ProfileView = React.createClass({
    accountRepository: new AccountRepository.AccountRepository(),
    isInvalidUser: true,

    getInitialState: function getInitialState() {

        if (this.props.params.name)
            this.accountRepository.getUserByName(this.props.params.name, this.onGetedUser);
        else
            this.accountRepository.getCurrentUser(this.onGetedUser);

        return { profile: {}};
    },

    onGetedUser: function (user){
        if (user == null)
            return;

      
        this.isInvalidUser = false;
        this.setState({ profile: JSON.parse(user) });       
    },


    render: function () {
        if (this.isInvalidUser)
            return (<div>Error</div>);

        return (
            <div className="row">
                <div className="col-xs-3">
                    <b>Login:</b> {this.state.profile.login}
                </div>
                <div className="col-xs-6">
                    <b>Name:</b> {this.state.profile.name}
                </div>
                <div className="col-xs-3">
                    <b>{this.state.profile.isEmployee ? "Employee" : "Client"}</b>
                </div>                            
            </div>
        );
    }
});

exports.ProfileView = ProfileView;