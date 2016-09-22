"use strict";

/// <reference path="components/itemsview/body/items.js" />

var ItemsView = React.createClass({
    displayName: "ItemsView",

    render: function render() {
        return React.createElement(
            "div",
            { className: "app" },
            React.createElement(Items, null)
        );
    }
});

ReactDOM.render(React.createElement(ItemsView, null), document.getElementById('root'));