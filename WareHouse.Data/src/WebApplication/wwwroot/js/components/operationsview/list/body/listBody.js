"use strict";

var ListBody = React.createClass({
    displayName: "ListBody",

    render: function render() {
        if (this.props.hidden) return React.createElement("div", null);

        var data = this.props.values;
        var itemclick = this.props.click;
        var filter = this.props.filter;

        var itemsTemplate = data.map(function(item, index) {
            if (!item.toLowerCase().includes(filter.toLowerCase())) return;

            return React.createElement(
                "div",
                { className: "people-list-item", key: index, onClick: itemclick },
                item
            );
        });

        return React.createElement(
            "div",
            { className: "people-list-body" },
            itemsTemplate
        );
    }
});