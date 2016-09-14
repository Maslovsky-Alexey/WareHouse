"use strict";

var ListBody = React.createClass({
    displayName: "ListBody",

    render: function render() {
        var data = this.props.values;
        var itemclick = this.props.click;

        var itemsTemplate = data.map(function (item, index) {
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

var List = React.createClass({
    displayName: "List",

    items: ['Igor A.A.', 'Vasy A.Q.', 'Ira A.A.', 'Orig A.F.'],

    getInitialState: function getInitialState() {
        return { viewItems: this.items };
    },

    search: function search(text) {
        this.state.viewItems = [];

        for (var i = 0; i < this.items.length; i++) {
            if (this.items[i].toLowerCase().includes(text.toLowerCase())) this.state.viewItems.push(this.items[i]);
        }

        if (this.state.viewItems.length == 1) this.curItem = this.state.viewItems[0]; else this.curItem = "";

        this.setState({ viewItems: this.state.viewItems });
    },

    changeSearchText: function changeSearchText(e) {
        this.search($(e.target).val());
    },

    click: function click(e) {
        var value = $(e.target).text();

        $(e.target).parent().parent().find("input").val(value);
        this.search(value);
    },

    render: function render() {
        var classname = "people-list " + this.props.side;
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
                React.createElement("input", { className: "form-control people-list-input", onKeyUp: this.changeSearchText })
            ),
            React.createElement(ListBody, { values: this.state.viewItems, click: this.click })
        );
    }

});

var NewOperartionView = React.createClass({
    displayName: "NewOperartionView",

    items: [],

    getInitialState: function getInitialState() {
        return { a: this.items };
    },

    modeChange: function modeChange(e) {

        if ($("#supply").prop("checked")) { } else { }
    },

    DeleteItem: function DeleteItem(index) {
        this.items.splice(index, 1);
        this.setState({ items: this.items });
    },

    AddItem: function AddItem() {
        this.items.push({ name: 'noname', count: 0 });
        this.setState({ a: this.items });
    },

    Send: function Send(e) {
        var input_name = $(e.target).parent().find(".item_name");
        var input_count = $(e.target).parent().find(".item_count");
        console.debug($("#supply:checked"));

        if ($("#supply:checked").length > 0)
            addItem(this.CreateItemValue(input_name.val(), input_count.val()), function () {
                input_name.val('');
                input_count.val('');
            });
        else
            removeItem(this.CreateItemValue(input_name.val(), input_count.val()), function () {
                input_name.val('');
                input_count.val('');
            });
    },

    CreateItemValue: function(name, count){
        return {
            name: name,
            count: count
        };
    },

    render: function render() {

        return React.createElement(
            "div",
            { className: "row" },
            React.createElement(
                "div",
                { className: "col-xs-3" },
                React.createElement(List, { title: "Providers", side: "left" })
            ),
            React.createElement(
                "div",
                { className: "col-xs-6" },
                React.createElement(
                    "label",
                    { className: "radio-inline radioleft" },
                    React.createElement("input", { type: "radio", name: "inlineRadioOptions", id: "supply", value: "supply", onChange: this.modeChange }),
                    " Supply"
                ),
                React.createElement(
                    "label",
                    { className: "radio-inline radioright" },
                    React.createElement("input", { type: "radio", name: "inlineRadioOptions", id: "order", value: "order", onChange: this.modeChange }),
                    " Order"
                ),
                React.createElement("input", { className: "form-control item_name", placeholder: "item name" }),
                React.createElement("input", { className: "form-control item_count", placeholder: "count" }),
                React.createElement(
                    "button",
                    { className: "btn btn-success btn-block btn-sm", onClick: this.Send },
                    "Send"
                )
            ),
            React.createElement(
                "div",
                { className: "col-xs-3" },
                React.createElement(List, { title: "Clients", side: "right" })
            )
        );
    }
});

ReactDOM.render(React.createElement(NewOperartionView, null), document.getElementById('root'));