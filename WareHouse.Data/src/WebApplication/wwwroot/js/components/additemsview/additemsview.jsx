var React = require('react');
var ReactDom = require('react-dom');

var ItemRepository = require('../../repositories/itemrepository.js');
var InputCompiler = require('../../autocompiler/inputcompiler.jsx');

var AddItemsView = React.createClass({
    itemsRepos: new ItemRepository.ItemRepository(),

    items: [],

    getInitialState: function () {
        this.itemsRepos.getItems(this.onItemsGeted);

        return {};
    },

    onItemsGeted: function(data){
        this.items = data;

        this.forceUpdate();
    },


    Add: function Send(e) {
        var name = $(e.target).parent().find('input').val();

        if (this.IsFormValid(name))
            //TODO: Отображение сообщений должно быть унифицировано во всем проекте.
            alert('Error');

        var sender = this;

        this.itemsRepos.addItem(this.CreateItemValue(name), function () {
            sender.itemsRepos.getItems(this.onItemsGeted);
            sender.emptyControlItems($(e.target).parent().find('input'));
        });                
    },

    emptyControlItems: function (input_name) {
        input_name.val('');
    },

    CreateItemValue: function (name) {       
        return {
            name: name
        };
    },

    IsFormValid: function(name){
        return !this.IsEmptyString(name);
    },

    IsEmptyString: function (str) {
        return str.replace(" ", "") == "";
    },

    render: function () {
        return (
            <div>
                <InputCompiler.InputCompiler items={this.items} />

                <button className="btn btn-success btn-block btn-sm" onClick={this.Add}>Add</button>
            </div>
            )
    }
});

exports.AddItemsView = AddItemsView;