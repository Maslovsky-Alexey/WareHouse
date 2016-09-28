"use strict";

/// <reference path="../../../../repositories/itemstatusrepository.js" />

var StatusSelect = React.createClass({
    displayName: "StatusSelect",


    changeValue: function changeValue(e) {
        var selectedItem = $(e.target).find(":selected");

        this.props.onchangevalue($(e.target).val(), selectedItem.attr('id').replace("status-", ""));
    },

    render: function render() {
        var options = this.props.items.map(function (item, index) {
            if (index == 0) return React.createElement(
                "option",
                { key: index, id: 'status-' + item.id, active: true },
                item.name
            ); else return React.createElement(
                "option",
                { key: index, id: 'status-' + item.id },
                item.name
            );
        });

        if (this.props.items && this.props.items.length > 0) this.props.onchangevalue(this.props.items[0].name, this.props.items[0].id);

        return React.createElement(
            "select",
            { className: "form-control", onChange: this.changeValue },
            options
        );
    }
});