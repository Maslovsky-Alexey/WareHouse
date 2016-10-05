/// <reference path="../../repositories/accountrepository.js" />

var LoginView = React.createClass({
    accountRepository: new AccountRepository(),

    Send: function(){
        var name = $("#username1").val();
        var password = $("#password1").val();

        this.accountRepository.login(name, password, this.loginSuccess);
    },

    loginSuccess: function(isSuccess){
        if (isSuccess)
            alert("YAHOOO!");
        else
            alert("OOOPPS :( ");   //TODO: измменить на нормальное отображение
    },

    render: function () {

        return (
            <div className="login-form">   
                <div className="form-group">
                    <label htmlFor="username1">Username</label>
                    <input className="form-control" id="username1" placeholder="Username"/>
                </div>
                <div className="form-group">
                    <label htmlFor="password1">Password</label>
                    <input type="password" className="form-control" id="password1" placeholder="Password"/>
                </div>
                <button type="submit" className="btn btn-default" onClick={this.Send}>Submit</button>
            </div>
        );
    }
});

ReactDOM.render(
  <LoginView />,
  document.getElementById('root')
);