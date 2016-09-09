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

        $("#people-list-input").val(value);
        this.search(value);
    },

    render: function () {
        var classname = "people-list " + this.props.side;

        return (
            <div className={classname}>
                <div className="people-list-head">
                    <div className="people-list-title">
                        {this.props.title}
                    </div>
                    <input className="form-control" onKeyUp={this.changeSearchText} id="people-list-input"/>
                </div>
                <ListBody values={this.state.viewItems} click={this.click}/>
            </div>
        );
    }

});


var NewOperartionView = React.createClass({
    modeChange: function (e) {

        if ($("#supply").prop("checked")) {
            
        } else {
            
        }
            
    },

    render: function() {
        return (
            <div className="row">
                <div className="col-xs-3">
                    <List title="Providers" side="left" />
                </div>
                <div className="col-xs-6">
                    <label className="radio-inline">
                      <input type="radio" name="inlineRadioOptions" id="supply" value="supply" onChange={this.modeChange} /> Supply
                    </label>
                    <label className="radio-inline">
                      <input type="radio" name="inlineRadioOptions" id="order" value="order" onChange={this.modeChange} /> Order
                    </label>
                    <div className="row">
                        <div className="col-xs-3 item-edit">
                            <input className="form-control" placeholder="item name" />
                            <input className="form-control" placeholder="Count" />
                            <button className="btn btn-danger btn-block btn-sm">Delete</button>
                        </div>
                        <div className="col-xs-3 item-edit">
                            <input className="form-control" placeholder="item name" />
                            <input className="form-control" placeholder="Count" />
                            <button className="btn btn-danger btn-block btn-sm">Delete</button>
                        </div>
                    </div>

                    <button className="btn btn-default btn-block btn-sm">Add</button>
                    <button className="btn btn-success btn-block btn-sm">Send</button>
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