var InputCompiler = React.createClass({

    getInitialState: function () {
        return { viewItems: [] };
    },

    click: function(e){
        $(e.target).parent().parent().find(".item_name").val($(e.target).text());
        $(e.target).parent().parent().find(".item_name").attr('id',  $(e.target).attr('id'));

        this.setState({ viewItems: [] }); 
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

        this.setId(e, value);

        this.setState({ viewItems: data });
    },

    setId: function(e, value){
        var item = this.props.items.filter(function (item, index) {
            return item.name.toLowerCase() == value.toLowerCase();
        });

        if (item.length > 0)
            $(e.target).attr('id', item[0].id);
        else
            $(e.target).attr('id', '-1');
    },

    render: function () {
      
        var click = this.click;
        var items = this.state.viewItems.map(function (item, index) {
            return (
                <div className="compiler-item" key={index} onClick={click} id={item.id}>
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