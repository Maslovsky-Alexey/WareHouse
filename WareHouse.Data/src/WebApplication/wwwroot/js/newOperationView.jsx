

var ListBody = React.createClass({
    render: function () {
        if (this.props.hidden)
            return (<div></div>);

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
        var value = $(e.target).val();
        this.search(value);
        this.props.changevalue(value);
    },

    click: function (e) {
        var value = $(e.target).text();

        $(e.target).parent().parent().find("input").val(value);
        this.search(value);
        this.props.changevalue(value);
    },

    render: function () {
        var classname = "people-list " + this.props.side + (this.props.active ? " valid" : " invalid");
        this.side = this.props.side;

        return (
            <div className={classname}>
                <div className="people-list-head">
                    <div className="people-list-title">
                        {this.props.title}
                    </div>
                    <input className="form-control people-list-input" onKeyUp={this.changeSearchText} disabled={!this.props.active}/>
                </div>
                <ListBody values={this.state.viewItems} click={this.click} hidden={!this.props.active}/>
            </div>
        );
    }

});


var NewOperartionView = React.createClass({
    items: [],
    listItem: '',

    getInitialState: function(){
        var sender = this;
        getItems(function (data) {
            sender.items = data.map(function (item) {
                return item.name;
            });
            sender.setState({});
        });

        return {supplymode: true};
    },

    modeChange: function (e) {
        this.setState({ supplymode: !this.state.supplymode });
    },

    Send: function Send(e) {
        var input_name = $(e.target).parent().find(".item_name");
        var input_count = $(e.target).parent().find(".item_count");
        var item = this.CreateItemValue(input_name.val(), input_count.val());

        this.Validation(input_name, input_count);

        if(this.state.supplymode)
            addItem(item, function () { input_name.val(''); input_count.val(''); });
        else
            removeItem(item, function () { input_name.val(''); input_count.val(''); });
    },

    CreateItemValue: function(name, count){
        return {
            name: name,
            count: count
        };
    },

    Validation: function(name, count){

    },

    selectedItem: function(item){

    },

    SelectedListItem: function(item){
        this.listItem = item;
    },

    render: function () {

        return (
            <div className="row">
                <div className="col-xs-3">
                    <List title="Providers" side="left" active={this.state.supplymode} changevalue={this.SelectedListItem}/>
                </div>
                <div className="col-xs-6">
                    <label className="radio-inline radioleft">
                      <input type="radio" name="inlineRadioOptions" id="supply" value="supply" onChange={this.modeChange} checked= {this.state.supplymode}/> Supply
                    </label>
                    <label className="radio-inline radioright">
                      <input type="radio" name="inlineRadioOptions" id="order" value="order" onChange={this.modeChange} checked= {!this.state.supplymode}/> Order
                    </label>

                    <InputCompiler items={this.items} valuechanged={this.selectedItem}/>
                    <input className="form-control item_count" placeholder="count" />


                    <button className="btn btn-success btn-block btn-sm" onClick={this.Send}>Send</button>
                </div>
                <div className="col-xs-3">
                    <List title="Clients" side="right" active={!this.state.supplymode} changevalue={this.selectedlistitem}/>
                </div>                            
            </div>
        );
    }
});

ReactDOM.render(
  <NewOperartionView />,
  document.getElementById('root')
);