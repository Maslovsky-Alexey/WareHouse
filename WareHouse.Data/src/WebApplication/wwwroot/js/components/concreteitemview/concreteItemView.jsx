var React = require("react");
var ReactDom = require("react-dom");

var WarehouseItemsRepository = require("../../repositories/warehouseitemrepository.js").WarehouseItemsRepository;

var ConcreteItemView = React.createClass({
    itemRepos: new WarehouseItemsRepository(),

    getInitialState: function getInitialState() {
        this.itemRepos.getItemById(this.props.params.id, this.onItemGeted);
        return { item: null };
    },

    onItemGeted: function(item) {
        if (item == null)
            return;

        this.setState({ item: item });
    },

    render: function() {
        if (this.state.item == null)
            return (<div>Item not found</div>);

        return (
            <div>
                <div className="col-sm-5">
                    <div className="concrete-item-info">Name: {this.state.item.name}</div>
                    <div className="concrete-item-info">Count: {this.state.item.count}</div>
                    <div className="concrete-item-info">Status: {this.state.item.status}</div>
                    <button className="form-control btn-success">Confirm supply</button>
                    <button className="form-control btn-danger">Return supply</button>
                </div>

            </div>
        );
    }
});

exports.ConcreteItemView = ConcreteItemView;