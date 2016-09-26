"use strict";

/// <reference path="components/itemsview/body/items.js" />
/// <reference path="../react-input-range/react-input-range.min.js" />

var FilterForm = React.createClass({
    displayName: "FilterForm",

    values: { min: 0, max: 0 },
    isFirst: true,

    componentWillReceiveProps: function componentWillReceiveProps(props) {
        if (this.isFirst)
            this.values = { min: props.mincount, max: props.maxcount };

        this.isFirst = false;
    },

    getInitialState: function getInitialState() {
        this.values = { min: this.props.mincount, max: this.props.maxcount };
        return { asc: true };
    },

    handleValuesChange: function handleValuesChange(component, values) {
        this.values = values;
        this.forceUpdate();
    },

    changeOrder: function changeOrder() {
        this.setState({ values: this.state.values, asc: !this.state.asc });
    },

    setOrderDown: function setOrderDown() {
        $("#down").addClass("active-arrow");
        $("#up").removeClass("active-arrow");
    },

    changeSearch: function changeSearch(e) {
        var value = $(e.target).val();

        this.props.search(value);
    },

    filterComplete: function filterComplete(e) {
        var filter = "?";

        var search = $("#search-name-input").val();

        var orderby = $("#property-order-selection").val();

        var isDown = $('#down').hasClass("active-arrow");

        this.props.search(search, this.values.min, this.values.max, orderby, isDown);
    },

    render: function render() {
        var classNameUp = "fa fa-long-arrow-up " + (this.state.asc ? "active-arrow" : "");
        var classNameDown = "fa fa-long-arrow-down " + (!this.state.asc ? "active-arrow" : "");

        return React.createElement(
            "div",
            { className: "filter-form" },
            React.createElement(
                "div",
                { className: "row" },
                React.createElement("div", { className: "col-xs-7" }),
                React.createElement(
                    "div",
                    { className: "col-xs-5" },
                    React.createElement("input", { className: "form-control search-name-input", placeholder: "Search", onKeyUp: this.changeSearch, id: "search-name-input" })
                )
            ),
            React.createElement(
                "div",
                { className: "row margin-top-5" },
                React.createElement(
                    "div",
                    { className: "col-xs-2 padding-right-0" },
                    React.createElement(
                        "select",
                        { className: "form-control property-order-selection", id: "property-order-selection" },
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
                    { className: "col-xs-2 padding-left-0" },
                    React.createElement("i", { className: classNameUp, "aria-hidden": "true", onClick: this.changeOrder, id: "up" }),
                    React.createElement("i", { className: classNameDown, "aria-hidden": "true", onClick: this.changeOrder, id: "down" })
                ),
                React.createElement(
                    "div",
                    { className: "col-xs-5" },
                    React.createElement(InputRange, {
                        className: "input-range",
                        maxValue: this.props.maxcount,
                        minValue: this.props.mincount,
                        value: this.values,
                        onChange: this.handleValuesChange.bind(this),
                        labelSuffix: " count"
                    })
                ),
                React.createElement(
                    "div",
                    { className: "col-xs-3" },
                    React.createElement(
                        "button",
                        { className: "form-control", onClick: this.filterComplete },
                        "Search"
                    )
                )
            ),
            React.createElement("div", null)
        );
    }
});