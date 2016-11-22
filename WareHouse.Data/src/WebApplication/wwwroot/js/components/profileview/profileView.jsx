
var React = require("react");
var ReactDom = require("react-dom");

var AccountRepository = require("../../repositories/accountrepository.js");
var OrderRepository = require("../../repositories/orderrepository.js").OrderRepository;
var SupplyRepository = require("../../repositories/supplyrepository.js").SupplyRepository;

var ItemsFiltredView = require("./itemsfiltredview/itemsfiltredview.jsx").ItemsFiltredView;

var EmployeeView = require("./employeeview/employeeview.jsx").EmployeeView;
var ClientView = require("./clientview/clientview.jsx").ClientView;

var ProfileView = React.createClass({
    accountRepository: new AccountRepository.AccountRepository(),
    suppliesRepository: new SupplyRepository(),
    ordersRepository: new OrderRepository(),

    getInitialState: function getInitialState() {

        if (this.props.params.name)
            this.accountRepository.getUserByName(this.props.params.name, this.onGetedUser);
        else
            this.accountRepository.getCurrentUser(this.onGetedUser);

        return { profile: {}, isInvalidUser: true, orders: [], supplies: [] };
    },

    onSuppliesGeted: function(supplies) {
        this.setState({
            profile: this.state.profile,
            isInvalidUser: this.state.isInvalidUser,
            orders: this.state.orders,
            supplies: supplies
        });
    },

    onOrdersGeted: function (orders) {
        this.setState({
            profile: this.state.profile,
            isInvalidUser: this.state.isInvalidUser,
            orders: orders,
            supplies: this.state.supplies
        });
    },

    onGetedUser: function(user) {
        if (user == null)
            return;

        this.setState({
            profile: user,
            isInvalidUser: false,
            orders: this.state.orders,
            supplies: this.state.supplies
        });

        if (user.isEmployee === true) {
            this.suppliesRepository.getSupplies(this.onSuppliesGeted);
            this.ordersRepository.getOrders(this.onOrdersGeted);
        }
        else
            this.ordersRepository.getClientOrders(user.name, this.onOrdersGeted);
    },


    render: function() {

        if (this.state.isInvalidUser)
            return (<div>Error</div>);

        var userView = this.state.profile.isEmployee === true ?
            (<EmployeeView orders={this.state.orders} supplies={this.state.supplies } />) : (<ClientView orders={this.state.orders } />);

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
                {userView}
                </div>            
        );
    }
});

exports.ProfileView = ProfileView;