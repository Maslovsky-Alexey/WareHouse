"use strict";

/// <reference path="components/itemsview/body/items.js" />
/// <reference path="../react-input-range/react-input-range.min.js" />


var ItemsView = React.createClass({
    displayName: "ItemsView",


    getInitialState: function getInitialState() {
        return { values: { min: 2, max: 6 }, asc: true };
    },

    handleValuesChange: function handleValuesChange(component, values) {
        this.setState({
            values: values
        });
    },

    changeOrder: function changeOrder() {
        this.setState({ values: this.state.values, asc: !this.state.asc });
    },

    setOrderDown: function setOrderDown() {
        $("#down").addClass("active-arrow");
        $("#up").removeClass("active-arrow");
    },

    render: function render() {
        var classNameUp = "fa fa-long-arrow-up " + (this.state.asc ? "active-arrow" : "");
        var classNameDown = "fa fa-long-arrow-down " + (!this.state.asc ? "active-arrow" : "");

        return React.createElement(
            "div",
            { className: "app" },
            React.createElement(
                "div",
                { className: "row" },
                React.createElement(
                    "div",
                    { className: "col-xs-7" },
                    React.createElement("input", { className: "form-control search-name-input" })
                ),
                React.createElement(
                    "div",
                    { className: "col-xs-2" },
                    React.createElement(
                        "select",
                        { className: "form-control" },
                        React.createElement(
                            "option",
                            null,
                            "Name"
                        ),
                        React.createElement(
                            "option",
                            null,
                            "Count"
                        )
                    )
                ),
                React.createElement(
                    "div",
                    { className: "col-xs-1" },
                    React.createElement("i", { className: classNameUp, "aria-hidden": "true", onClick: this.changeOrder, id: "up" }),
                    React.createElement("i", { className: classNameDown, "aria-hidden": "true", onClick: this.changeOrder, id: "down" })
                )
            ),
            React.createElement(
                "button",
                { className: "form-control" },
                "Search"
            ),
            React.createElement(
                "div",
                null,
                React.createElement(InputRange, {
                    className: "input-range",
                    maxValue: 20,
                    minValue: 0,
                    value: this.state.values,
                    onChange: this.handleValuesChange.bind(this),
                    labelSuffix: " count"
                })
            ),
            React.createElement(Items, null)
        );
    }
});

ReactDOM.render(React.createElement(ItemsView, null), document.getElementById('root'));