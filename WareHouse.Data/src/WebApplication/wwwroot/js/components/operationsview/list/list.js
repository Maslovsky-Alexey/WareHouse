"use strict";

/// <reference path="body/listbody.js" />

var List = React.createClass({
    displayName: "List",

    items: [],
    filter: "",

    search: function search(text) {
        this.filter = text;

        this.forceUpdate();
    },

    changeSearchText: function changeSearchText(e) {
        var value = $(e.target).val();
        this.search(value);
        this.props.changevalue(value);
    },

    click: function click(e) {
        var value = $(e.target).text();

        $(e.target).parent().parent().find("input").val(value);
        this.search(value);
        this.props.changevalue(value);
    },

    render: function render() {
        this.items = this.props.items;

        var classname = "people-list " + this.props.side + (this.props.active ? " valid" : " invalid");
        this.side = this.props.side;

        return React.createElement(
            "div",
            { className: classname },
            React.createElement(
                "div",
                { className: "people-list-head" },
                React.createElement(
                    "div",
                    { className: "people-list-title" },
                    this.props.title
                ),
                React.createElement("input", { className: "form-control people-list-input", onKeyUp: this.changeSearchText, disabled: !this.props.active })
            ),
            React.createElement(ListBody, { values: this.items, click: this.click, hidden: !this.props.active, filter: this.filter })
        );
    }

});