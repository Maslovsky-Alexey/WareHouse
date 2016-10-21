var React = require("react");
var ReactDom = require("react-dom");


var ItemRepository = require("../../../repositories/itemrepository.js");
var OperationRepository = require("../../../repositories/operationrepository.js");
var StatusSelect = require("./elements/statusselect.jsx");

var FormOperations = React.createClass({
    itemsRepos: new ItemRepository.ItemRepository(),
    warehouseItems: new OperationRepository.OperationRepository(),

    items: [],
    itemId: -1,

    getInitialState: function() {
        this.itemsRepos.getItems(this.onItemsGeted);

        return { supplymode: true };
    },

    onItemsGeted: function(data) {
        this.items = data;
        this.forceUpdate();
    },

    modeChange: function(e) {
        if (this.props.changeMode)
            this.props.changeMode(!this.state.supplymode);

        this.setState({ supplymode: !this.state.supplymode });
    },

    Send: function Send(e) {
        var input_name = $(e.target).parent().find(".item_name");

        var input_count = $(e.target).parent().find(".item_count");

        if (!this.IsFormValid(input_count)) {
            alert("Pechal");
            return;
        }

        var sender = this;
        if (this.state.supplymode) {
            this.warehouseItems.addSupply(this.CreateSupplyModel(this.itemId, input_count.val()),
                function() { sender.emptyControlItems(input_name, input_count); });
        } else {
            this.warehouseItems.addOrder(this.CreateOrderModel(this.itemId, input_count.val()),
                function() { sender.emptyControlItems(input_name, input_count); });
        }
    },

    emptyControlItems: function(input_name, input_count) {
        input_count.val("");
    },

    CreateSupplyModel: function(id, count) {
        return {
            count: count,
            item: { id: id },
            provider: { id: this.props.actor },
            employee: {id: 1}//TODO: ЗАМЕНИТЬ!
        };
    },

    CreateOrderModel: function(id, count) {
        return {
            count: count,
            item: { id: id },
            client: { id: this.props.actor },
            employee: { id: 1 }//TODO: ЗАМЕНИТЬ!
        };
    },

    IsFormValid: function(count) {
        var countValue = parseInt(count.val());

        return !this.IsEmptyString(count.val()) && !Number.isNaN(countValue) && countValue > 0 && this.props.actor > -1;
    },

    IsEmptyString: function(str) {
        return str.replace(" ", "") == "";
    },

    onChangeStatus: function(status, statusId) {
        this.status = status;
        this.statusId = statusId;
    },

    itemSelected: function(name, id) {
        this.itemId = id;
    },

    render: function() {
        return (
            <div>
                <label className="radio-inline radioleft">
                    <input type="radio" name="inlineRadioOptions" id="supply" value="supply" onChange={this.modeChange}
                           checked={this.state.supplymode}/> Supply
                </label>
                <label className="radio-inline radioright">
                    <input type="radio" name="inlineRadioOptions" id="order" value="order" onChange={this.modeChange}
                           checked={!this.state.supplymode}/> Order
                </label>

                <StatusSelect.StatusSelect items={this.items} onchangevalue={this.itemSelected}/>

                <input className="form-control item_count" placeholder="count"/>
                <button className="btn btn-success btn-block btn-sm" onClick={this.Send}>Send</button>
            </div>
        );
    }
});

exports.FormOperations = FormOperations;