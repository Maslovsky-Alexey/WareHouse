var React = require('react');
var ReactDom = require('react-dom');

var About = React.createClass({
    render: function () {
        var itemInfo = this.props.itemInfo;
        return (
            <div className="caption">
                <h4 className="pull-right">count: {itemInfo.count}</h4>
                <h4><a href={itemInfo.link ? itemInfo.link : '#' }>{itemInfo.name ? itemInfo.name : 'Noname'}</a></h4>
                <p>{itemInfo.about}</p>
            </div>
            )
    }
});

exports.About = About;
