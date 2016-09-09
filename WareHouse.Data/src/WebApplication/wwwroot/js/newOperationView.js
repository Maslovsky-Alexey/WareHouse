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

        if (this.state.viewItems.length == 1) this.curItem = this.state.viewItems[0];else this.curItem = "";

        this.setState({ viewItems: this.state.viewItems });
    },

    changeSearchText: function changeSearchText(e) {
        this.search($(e.target).val());
    },

    click: function click(e) {
        var value = $(e.target).text();

        $("#people-list-input").val(value);
        this.search(value);
    },

    render: function render() {
        var classname = "people-list " + this.props.side;

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
                React.createElement("input", { className: "form-control", onKeyUp: this.changeSearchText, id: "people-list-input" })
            ),
            React.createElement(ListBody, { values: this.state.viewItems, click: this.click })
        );
    }

});

var NewOperartionView = React.createClass({
    displayName: "NewOperartionView",

    modeChange: function modeChange(e) {

        if ($("#supply").prop("checked")) {} else {}
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
                    { className: "radio-inline" },
                    React.createElement("input", { type: "radio", name: "inlineRadioOptions", id: "supply", value: "supply", onChange: this.modeChange }),
                    " Supply"
                ),
                React.createElement(
                    "label",
                    { className: "radio-inline" },
                    React.createElement("input", { type: "radio", name: "inlineRadioOptions", id: "order", value: "order", onChange: this.modeChange }),
                    " Order"
                ),
                React.createElement(
                    "div",
                    { className: "row" },
                    React.createElement(
                        "div",
                        { className: "col-xs-3 item-edit" },
                        React.createElement("input", { className: "form-control", placeholder: "item name" }),
                        React.createElement("input", { className: "form-control", placeholder: "Count" }),
                        React.createElement(
                            "button",
                            { className: "btn btn-danger btn-block btn-sm" },
                            "Delete"
                        )
                    ),
                    React.createElement(
                        "div",
                        { className: "col-xs-3 item-edit" },
                        React.createElement("input", { className: "form-control", placeholder: "item name" }),
                        React.createElement("input", { className: "form-control", placeholder: "Count" }),
                        React.createElement(
                            "button",
                            { className: "btn btn-danger btn-block btn-sm" },
                            "Delete"
                        )
                    )
                ),
                React.createElement(
                    "button",
                    { className: "btn btn-default btn-block btn-sm" },
                    "Add"
                ),
                React.createElement(
                    "button",
                    { className: "btn btn-success btn-block btn-sm" },
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