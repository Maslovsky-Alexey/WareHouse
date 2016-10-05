/// <reference path="../../repositories/accountrepository.js" />

var ProfileView = React.createClass({
    accountRepository: new AccountRepository(),
    isInvalidUser: true,

    getInitialState: function getInitialState() {
        this.accountRepository.getCurrentUser(this.onGetedUser);

        return { profile: {}};
    },

    onGetedUser: function (user){
        if (user == null)
            return;

        this.isInvalidUser = false;
        this.setState({ profile: user });
    },

    render: function () {
        if (this.isInvalidUser)
            return (<div>Error</div>);
        return (
            <div className="row">
                <div className="col-xs-3">
                    Login: {this.state.profile.login}
                </div>
                <div className="col-xs-6">
                    Name: {this.state.profile.name}
                </div>
                <div className="col-xs-3">
                    {this.state.profile.isEmployee ? "Employee" : "Client"}
                </div>                            
            </div>
        );
    }
});

ReactDOM.render(
  <ProfileView />,
  document.getElementById('root')
);