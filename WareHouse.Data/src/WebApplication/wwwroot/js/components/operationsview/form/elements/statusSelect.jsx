/// <reference path="../../../../repositories/itemstatusrepository.js" />

var StatusSelect = React.createClass({

    changeValue: function(e){
        var selectedItem = $(e.target).find(":selected");

        this.props.onchangevalue($(e.target).val(), selectedItem.attr('id').replace("status-", ""));
    },

    render: function () {
        var options = this.props.items.map(function (item, index) {
            if (index == 0)
                return (<option key={index} id={'status-' + item.id} active>{item.name}</option>);
            else
                return (<option key={index} id={'status-' + item.id}>{item.name}</option>);
        });

        if (this.props.items && this.props.items.length > 0)
            this.props.onchangevalue(this.props.items[0].name, this.props.items[0].id);

        return (
            <select className="form-control" onChange={this.changeValue}>
                {options}
            </select>
        )
     }
});