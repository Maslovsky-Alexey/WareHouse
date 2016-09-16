"use strict";

var ListBody = React.createClass({
    displayName: "ListBody",

    render: function render() {
        if (this.props.hidden) return React.createElement("div", null);

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
            React.createElement(ListBody, { values: this.state.viewItems, click: this.click, hidden: !this.props.active })
        );
    }

});

var NewOperartionView = React.createClass({
    displayName: "NewOperartionView",

    items: [],
    listItem: '',

    getInitialState: function getInitialState() {
        var sender = this;
        getItems(function (data) {
            sender.items = data.map(function (item) {
                return item.name;
            });
            sender.setState({});
        });

        return { supplymode: true };
    },

    modeChange: function modeChange(e) {
        this.setState({ supplymode: !this.state.supplymode });
    },

    Send: function Send(e) {
        var input_name = $(e.target).parent().find(".item_name");
        var input_count = $(e.target).parent().find(".item_count");
        var item = this.CreateItemValue(input_name.val(), input_count.val());

        this.Validation(input_name, input_count);

        if (this.state.supplymode) addItem(item, function () {
            input_name.val(''); input_count.val('');
        }); else removeItem(item, function () {
            input_name.val(''); input_count.val('');
        });
    },

    CreateItemValue: function CreateItemValue(name, count) {
        return {
            name: name,
            count: count
        };
    },

    Validation: function Validation(name, count) { },

    selectedItem: function selectedItem(item) { },

    SelectedListItem: function SelectedListItem(item) {
        this.listItem = item;
    },

    render: function render() {

        return React.createElement(
            "div",
            { className: "row" },
            React.createElement(
                "div",
                { className: "col-xs-3" },
                React.createElement(List, { title: "Providers", side: "left", active: this.state.supplymode, changevalue: this.SelectedListItem })
            ),
            React.createElement(
                "div",
                { className: "col-xs-6" },
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
                React.createElement(InputCompiler, { items: this.items, valuechanged: this.selectedItem }),
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
                React.createElement(List, { title: "Clients", side: "right", active: !this.state.supplymode, changevalue: this.selectedlistitem })
            )
        );
    }
});

ReactDOM.render(React.createElement(NewOperartionView, null), document.getElementById('root'));