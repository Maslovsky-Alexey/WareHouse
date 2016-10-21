
var React = require("react");
var ReactDom = require("react-dom");

var ItemsFiltredView = require("../itemsfiltredview/itemsfiltredview.jsx").ItemsFiltredView;

var orderProperties = require("../models/ordermodel.js").OrderModel;
var supplyProperties = require("../models/supplymodel.js").SupplyModel;

var AccountRepository = require("../../../repositories/accountrepository.js").AccountRepository;

var EmployeeView = React.createClass({
    accountRepository: new AccountRepository(),

    getInitialState: function getInitialState() {
        return {};
    },

    registerClient: function () {
        this.accountRepository.registerClient($('#client-name').val(), $('#client-password').val(), () => {
            $('#client-name').val('');
            $('#client-password').val('');
        });
    },

    registerEmployee: function () {
        this.accountRepository.registerEmployee($('#employee-name').val(), $('#employee-password').val(), () => {
            $('#employee-name').val('');
            $('#employee-password').val('');
        });
    },

    render: function () {
        return (
            <div className="row">
                Client name <input id='client-name'/>
                Password <input id='client-password'/>
                <button onClick={this.registerClient}>Add</button>
                <br/>

                Employee name <input id='employee-name'/>
                Password <input id='employee-password'/>
                <button onClick={this.registerEmployee}>Add</button>
                <br/>

                Orders
                <ItemsFiltredView items={this.props.orders} properties={orderProperties}/>
                Supplies
                <ItemsFiltredView items={this.props.supplies} properties={supplyProperties}/>
            </div>
        );
    }
});

exports.EmployeeView = EmployeeView;