
var React = require("react");
var ReactDom = require("react-dom");

var ItemsFiltredView = require("../itemsfiltredview/itemsfiltredview.jsx").ItemsFiltredView;
var orderProperties = require("../models/ordermodel.js").OrderModel;

var ClientView = React.createClass({
    render: function () {
        return (
            <div className="row">
                Orders
                <ItemsFiltredView items={this.props.orders} properties={orderProperties}/>
            </div>
        );
    }
});

exports.ClientView = ClientView;