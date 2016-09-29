'use strict';

/// <reference path="../../../repositories/itemrepository.js" />

/// <reference path="../../../autocompiler/inputcompiler.js" />

var AddItemsView = React.createClass({
    displayName: 'AddItemsView',

    itemsRepos: new ItemRepository(),

    items: [],

    getInitialState: function getInitialState() {
        this.itemsRepos.getItems(this.onItemsGeted);

        return {};
    },

    onItemsGeted: function onItemsGeted(data) {
        this.items = data;

        this.forceUpdate();
    },

    Add: function Send(e) {
        var name = $(e.target).parent().find('input').val();

        if (this.IsEmptyString(name)) alert('Error');

        var sender = this;
        var target = $(e.target);
        this.itemsRepos.addItem(this.CreateItemValue(name), function () {
            sender.itemsRepos.getItems(sender.onItemsGeted);
            target.parent().find('input').val('');
        });
    },

    emptyControlItems: function emptyControlItems(input_name) {
        input_name.val('');
    },

    CreateItemValue: function CreateItemValue(name) {
        return {
            name: name
        };
    },

    IsEmptyString: function IsEmptyString(str) {
        return str.replace(" ", "") == "";
    },

    render: function render() {
        return React.createElement(
            'div',
            null,
            React.createElement(InputCompiler, { items: this.items }),
            React.createElement(
                'button',
                { className: 'btn btn-success btn-block btn-sm', onClick: this.Add },
                'Add'
            )
        );
    }
});

ReactDOM.render(React.createElement(AddItemsView, null), document.getElementById('root'));