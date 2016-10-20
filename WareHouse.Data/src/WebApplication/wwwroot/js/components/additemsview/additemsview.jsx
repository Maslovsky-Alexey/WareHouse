var React = require("react");
var ReactDom = require("react-dom");

var ItemStore = require("../../stores/itemstore.js").ItemStore;
var Dispatcher = require("../../dispatcher/dispatcher.js").Dispatcher;
var InputCompiler = require("../../autocompiler/inputcompiler.jsx");

var AddItemsView = React.createClass({
    itemStore: ItemStore,

    componentDidMount: function() {
        this.itemStore.addOnChangeListener(this.onItemsGeted);
    },

    getInitialState: function() {
        return { items: this.itemStore.getItems() };
    },

    onItemsGeted: function(items) {
        console.debug(items);
        this.setState({ items: items });
    },


    Add: function Send(e) {
        var name = $(e.target).parent().find("input").val();

        if (this.IsFormValid(name))
            alert("Error");

        Dispatcher.dispatch({
            name: "add-item",
            data: this.CreateItemValue(name)
        });
    },

    emptyControlItems: function(input_name) {
        input_name.val("");
    },

    CreateItemValue: function(name) {
        return {
            name: name
        };
    },

    IsFormValid: function(name) {
        return !this.IsEmptyString(name);
    },

    IsEmptyString: function(str) {
        return str.replace(" ", "") == "";
    },

    render: function() {
        console.debug(this.state);
        return (
            <div>
                <InputCompiler.InputCompiler items={this.state.items}/>

                <button className="btn btn-success btn-block btn-sm" onClick={this.Add}>Add</button>
            </div>
        );
    }
});

exports.AddItemsView = AddItemsView;