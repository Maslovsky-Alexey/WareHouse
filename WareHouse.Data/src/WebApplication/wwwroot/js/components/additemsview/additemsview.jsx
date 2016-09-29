/// <reference path="../../../repositories/itemrepository.js" />

/// <reference path="../../../autocompiler/inputcompiler.js" />

var AddItemsView = React.createClass({
    itemsRepos: new CreateItemRepository(),

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

        //TODO: Валидация должна быть в отдельным методе или объекте
        if (this.IsEmptyString(name))
            //TODO: Отображение сообщений должно быть унифицировано во всем проекте.
            alert('Error');

        var sender = this;

        this.itemsRepos.addItem(this.CreateItemValue(name), function () {
            sender.itemsRepos.getItems(this.onItemsGeted);
            this.emptyControlItems($(e.target).parent().find('input'));
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

    IsEmptyString: function (str) {
        return str.replace(" ", "") == "";
    },

    render: function () {
        return (
            <div>
                <InputCompiler items={this.items} />

                <button className="btn btn-success btn-block btn-sm" onClick={this.Add}>Add</button>
            </div>
            )
    }
});

ReactDOM.render(
  <AddItemsView />,
  document.getElementById('root')
);