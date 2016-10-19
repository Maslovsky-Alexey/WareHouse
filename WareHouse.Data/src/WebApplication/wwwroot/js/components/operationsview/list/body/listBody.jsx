var React = require('react');
var ReactDom = require('react-dom');

var ListBody = React.createClass({
    render: function () {
        if (this.props.hidden)
            return (<div></div>);

        var data = this.props.values;
        var itemclick = this.props.click;
        var filter = this.props.filter;

        var itemsTemplate = data.map(function(item, index) {
            if (!item.name.toLowerCase().includes(filter.toLowerCase()))
                return;

            var id = "actor-" + item.id;

            return (
                <div className="people-list-item" key={index} onClick={() => itemclick(item.id, item.name)}>
                    {item.name}
                </div>
            );
        });

        return (
            <div className="people-list-body">
                {itemsTemplate}
            </div>
        );
    }
});

exports.ListBody = ListBody;