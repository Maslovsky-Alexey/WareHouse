var React = require('react');
var ReactDom = require('react-dom');


var Layout = React.createClass({


    render: function () {
            return (
            <div className="InputCompiler">
                HelloWord!
                <div>
                    {this.props.children}
                </div>
            </div>
        );
    }
});

exports.Layout = Layout;