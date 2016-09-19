"use strict";

var ListBody = React.createClass({
    displayName: "ListBody",

    render: function render() {
        if (this.props.hidden) return React.createElement("div", null);

        var data = this.props.values;
        var itemclick = this.props.click;
        var filter = this.props.filter;

        var itemsTemplate = data.map(function (item, index) {
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

var NewOperartionView = React.createClass({
    displayName: "NewOperartionView",

    items: [],
    listItem: '',
    providers: [],
    clients: [],

    getInitialState: function getInitialState() {
        var sender = this;
        getClients(this.onClientsGeted);
        getProviders(this.onProvidersGeted);

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

        if (!this.IsFormValid(input_name, input_count)) {
            alert("Pechal");
            return;
        }

        if (this.state.supplymode) {
            addItem(item, function () {
                input_name.val(''); input_count.val('');
            });
            addProvder({ name: this.listItem }, function () { });
        } else {
            removeItem(item, function () {
                input_name.val(''); input_count.val('');
            });
            addClient({ name: this.listItem }, function () { });
        }
    },

    CreateItemValue: function CreateItemValue(name, count) {
        return {
            name: name,
            count: count
        };
    },

    IsFormValid: function IsFormValid(name, count) {
        var countValue = parseInt(count.val());

        var isNameEmpty = this.IsEmptyString(name.val());
        var isNameCount = this.IsEmptyString(name.val());
        var isNameListItem = this.IsEmptyString(name.val());

        return (!isNameEmpty && !isNameCount && !isNameListItem) && (countValue != NaN && countValue > 0);
    },

    IsEmptyString: function IsEmptyString(str) {
        return str.replace(" ", "") == "";
    },

    selectedItem: function selectedItem(item) { },

    SelectedListItem: function SelectedListItem(item) {
        this.listItem = item;
    },

    onProvidersGeted: function onProvidersGeted(data) {
        this.providers = data.map(function (item) {
            return item.name;
        });

        this.setState({ supplymode: this.state.supplymode });
    },

    onClientsGeted: function onClientsGeted(data) {
        this.clients = data.map(function (item) {
            return item.name;
        });

        this.setState({ supplymode: this.state.supplymode });
    },

    render: function render() {

        return React.createElement(
            "div",
            { className: "row" },
            React.createElement(
                "div",
                { className: "col-xs-3" },
                React.createElement(List, { title: "Providers", side: "left", active: this.state.supplymode, changevalue: this.SelectedListItem, items: this.providers })
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
                React.createElement(List, { title: "Clients", side: "right", active: !this.state.supplymode, changevalue: this.selectedlistitem, items: this.clients })
            )
        );
    }
});

ReactDOM.render(React.createElement(NewOperartionView, null), document.getElementById('root'));