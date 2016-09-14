var ListBody = React.createClass({
    render: function() {
        var data = this.props.values;
        var itemclick = this.props.click;

        var itemsTemplate = data.map(function (item, index) {
            return (
                <div className="people-list-item" key={index} onClick={itemclick}>
                    {item}
                </div>
            )
        })

        return (
            <div className="people-list-body">
                {itemsTemplate}
            </div>
        );
    }
});

var List = React.createClass({
    items: ['Igor A.A.', 'Vasy A.Q.', 'Ira A.A.', 'Orig A.F.'],

    getInitialState: function () {
        return { viewItems: this.items};
    },

    search: function(text){
        this.state.viewItems = [];

        for (var i = 0; i < this.items.length; i++) {
            if (this.items[i].toLowerCase().includes(text.toLowerCase())) this.state.viewItems.push(this.items[i]);
        }

        if (this.state.viewItems.length == 1)
            this.curItem = this.state.viewItems[0];
        else
            this.curItem = "";

        this.setState({ viewItems: this.state.viewItems });
    },

    changeSearchText: function (e) {
        this.search($(e.target).val());
    },

    click: function (e) {
        var value = $(e.target).text();

        $(e.target).parent().parent().find("input").val(value);
        this.search(value);
    },

    render: function () {
        var classname = "people-list " + this.props.side;
        this.side = this.props.side;

        return (
            <div className={classname}>
                <div className="people-list-head">
                    <div className="people-list-title">
                        {this.props.title}
                    </div>
                    <input className="form-control people-list-input" onKeyUp={this.changeSearchText} />
                </div>
                <ListBody values={this.state.viewItems} click={this.click}/>
            </div>
        );
    }

});


var NewOperartionView = React.createClass({
    items: [],

    getInitialState: function () {
        return { a: this.items };
    },

    modeChange: function (e) {

        if ($("#supply").prop("checked")) {
            
        } else {
            
        }
            
    },

    DeleteItem: function (index) {
        this.items.splice(index, 1);
        this.setState({ items: this.items });
    },

    AddItem: function(){
        this.items.push({ name: 'noname', count: 0 });
        this.setState({ a: this.items });
    },

    Send: function Send(e) {
        var input_name = $(e.target).parent().find(".item_name");
        var input_count = $(e.target).parent().find(".item_count");
        console.debug($("#supply").prop("checked", true));

        if ($("#supply").prop("checked", true))
            addItem(this.CreateItemValue(input_name.val(), input_count.val()), function () {
                input_name.val('sup');
                input_count.val('');
            });
        else
            removeItem(this.CreateItemValue(input_name.val(), input_count.val()), function () {
                input_name.val('ord');
                input_count.val('');
            });
    },

    CreateItemValue: function (name, count) {
        return {
            name: name,
            count: count
        };
    },

    render: function () {

        return (
            <div className="row">
                <div className="col-xs-3">
                    <List title="Providers" side="left" />
                </div>
                <div className="col-xs-6">
                    <label className="radio-inline radioleft">
                      <input type="radio" name="inlineRadioOptions" id="supply" value="supply" onChange={this.modeChange} /> Supply
                    </label>
                    <label className="radio-inline radioright">
                      <input type="radio" name="inlineRadioOptions" id="order" value="order" onChange={this.modeChange} /> Order
                    </label>

                    <input className="form-control item_name" placeholder="item name" />
                    <input className="form-control item_count" placeholder="count" />


                    <button className="btn btn-success btn-block btn-sm" onClick={this.Send}>Send</button>
                </div>
                <div className="col-xs-3">
                    <List title="Clients" side="right" />
                </div>                            
            </div>
        );
    }
});

ReactDOM.render(
  <NewOperartionView />,
  document.getElementById('root')
);