"use strict";

/// <reference path="../../../repositories/itemrepository.js" />
/// <reference path="../../../repositories/providerrepository.js" />
/// <reference path="../../../repositories/clientrepository.js" />

/// <reference path="../../../autocompiler/inputcompiler.js" />

var FormOperations = React.createClass({
    displayName: "FormOperations",

    itemsRepos: new CreateItemRepository(),

    items: [],

    getInitialState: function getInitialState() {
        this.itemsRepos.getItems(this.onItemsGeted);

        return { supplymode: true };
    },

    onItemsGeted: function onItemsGeted(data) {
        this.items = data;

        this.forceUpdate();
    },

    modeChange: function modeChange(e) {
        if (this.props.changeMode) this.props.changeMode(!this.state.supplymode);

        this.setState({ supplymode: !this.state.supplymode });
    },

    Send: function Send(e) {
        var input_name = $(e.target).parent().find(".item_name");

        var input_count = $(e.target).parent().find(".item_count");
        var item = this.CreateItemValue(input_name.attr('id'), input_name.val(), input_count.val());

        if (!this.IsFormValid(input_name, input_count)) {
            alert("Pechal");
            return;
        }

        var sender = this;
        if (this.state.supplymode) {
            new CreateItemRepository().addItem(item, function () {
                sender.emptyControlItems(input_name, input_count);
            });
            new CreateProviderRepository().addProvder({ name: this.props.actor }, function () { });
        } else {
            new CreateItemRepository().removeItem(item, function () {
                sender.emptyControlItems(input_name, input_count);
            });
            new CreateClientRepository().addClient({ name: this.props.actor }, function () { });
        }
    },

    emptyControlItems: function emptyControlItems(input_name, input_count) {
        input_name.val('');
        input_count.val('');
        input_name.attr('id', '');
    },

    CreateItemValue: function CreateItemValue(id, name, count) {
        return {
            name: name,
            count: count,
            id: id
        };
    },

    IsFormValid: function IsFormValid(name, count) {
        var countValue = parseInt(count.val());

        return !this.IsEmptyString(name.val()) && !this.IsEmptyString(count.val()) && !Number.isNaN(countValue) && countValue > 0 && !this.IsEmptyString(this.props.actor);
    },

    IsEmptyString: function IsEmptyString(str) {
        return str.replace(" ", "") == "";
    },

    render: function render() {
        return React.createElement(
            "div",
            null,
            React.createElement(
                "label",
                { className: "radio-inline radioleft" },
                React.createElement("input", { type: "radio", name: "inlineRadioOptions", id: "supply", value: "supply", onChange: this.modeChange, checked: this.state.supplymode }),
                " Supply"
            ),
            React.createElement(
                "label",
                { className: "radio-inline radioright" },
                React.createElement("input", { type: "radio", name: "inlineRadioOptions", id: "order", value: "order", onChange: this.modeChange, checked: !this.state.supplymode }),
                " Order"
            ),
            React.createElement(InputCompiler, { items: this.items }),
            React.createElement("input", { className: "form-control item_count", placeholder: "count" }),
            React.createElement(
                "button",
                { className: "btn btn-success btn-block btn-sm", onClick: this.Send },
                "Send"
            )
        );
    }
});