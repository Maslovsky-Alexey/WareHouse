var InputCompiler = React.createClass({

    getInitialState: function () {
        return { viewItems: [] };
    },

    click: function(e){
        $(e.target).parent().parent().find(".item_name").val($(e.target).text());
        this.setState({ viewItems: [] });

        if (this.props.valuechanged)
            this.props.valuechanged(this.props.items[$(e.target).attr('id')]);
    },

    onchange: function(e){
        var data = [];
        var value = $(e.target).val();

        if (value.replace(' ', '') == '')
            data = [];
        else
            data = this.props.items.filter(function (item, index) {
                return item.name.toLowerCase().includes(value.toLowerCase());
            });

        this.setState({ viewItems: data });

        if (this.props.valuechanged)
            this.props.valuechanged(value);
    },

    render: function () {
      
        var click = this.click;
        var items = this.state.viewItems.map(function (item, index) {
            return (
                <div className="compiler-item" key={index} onClick={click} id={index}>
                    {item.name}
                </div>
            )
        });

        return (
                <div className="InputCompiler">
                    <input className="form-control item_name" placeholder="item name" onChange={this.onchange} />
                    <div className="compiler-list-items">
                        {items}
                    </div>
                </div>
            );
    }
});