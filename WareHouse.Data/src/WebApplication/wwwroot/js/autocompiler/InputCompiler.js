"use strict";

var InputCompiler = React.createClass({
    displayName: "InputCompiler",


    getInitialState: function getInitialState() {
        return { viewItems: [] };
    },

    click: function click(e) {
        $(e.target).parent().parent().find(".item_name").val($(e.target).text());
        $(e.target).parent().parent().find(".item_name").attr('id', $(e.target).attr('id'));

        this.setState({ viewItems: [] });
    },

    onchange: function onchange(e) {
        var data = [];
        var value = $(e.target).val();

        if (value.replace(' ', '') == '') data = []; else data = this.props.items.filter(function (item, index) {
            return item.name.toLowerCase().includes(value.toLowerCase());
        });

        this.setId(e, value);

        this.setState({ viewItems: data });
    },

    setId: function setId(e, value) {
        var item = this.props.items.filter(function (item, index) {
            return item.name.toLowerCase() == value.toLowerCase();
        });

        if (item.length > 0) $(e.target).attr('id', item[0].id); else $(e.target).attr('id', '-1');
    },

    render: function render() {

        var click = this.click;
        var items = this.state.viewItems.map(function (item, index) {
            return React.createElement(
                "div",
                { className: "compiler-item", key: index, onClick: click, id: item.id },
                item.name
            );
        });

        return React.createElement(
            "div",
            { className: "InputCompiler" },
            React.createElement("input", { className: "form-control item_name", placeholder: "item name", onChange: this.onchange }),
            React.createElement(
                "div",
                { className: "compiler-list-items" },
                items
            )
        );
    }
});