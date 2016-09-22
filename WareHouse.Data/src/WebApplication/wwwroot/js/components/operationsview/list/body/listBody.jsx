var ListBody = React.createClass({
    render: function () {
        if (this.props.hidden)
            return (<div></div>);

        var data = this.props.values;
        var itemclick = this.props.click;
        var filter = this.props.filter;

        var itemsTemplate = data.map(function (item, index) {
            if (!item.toLowerCase().includes(filter.toLowerCase()))
                return;

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