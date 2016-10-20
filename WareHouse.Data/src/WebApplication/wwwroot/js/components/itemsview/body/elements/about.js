"use strict";

var About = React.createClass({
    displayName: "About",

    render: function render() {
        var itemInfo = this.props.itemInfo;
        return React.createElement(
            "div",
            { className: "caption" },
            React.createElement(
                "h4",
                { className: "pull-right" },
                "count: ",
                itemInfo.count
            ),
            React.createElement(
                "h4",
                null,
                React.createElement(
                    "a",
                    { href: itemInfo.link ? itemInfo.link : "#" },
                    itemInfo.name ? itemInfo.name : "Noname"
                )
            ),
            React.createElement(
                "p",
                null,
                itemInfo.about
            )
        );
    }
});