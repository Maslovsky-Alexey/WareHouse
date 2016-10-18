var React = require('react');
var ReactDom = require('react-dom');
var Link = require('react-router').Link;

var Layout = React.createClass({

    getInitialState: function getInitialState() {

        return {};
    },

    render: function () {
            return (
            <div className="InputCompiler">
                <div className="navbar navbar-inverse navbar-fixed-top">
                    <div className="container">
                        <div className="navbar-header">
                            <a className="navbar-brand">ВВарехаузе</a>
                        </div>
                        <div className="navbar-collapse collapse">
                            <ul className="nav navbar-nav">
                                <li><Link to="/operations">New operation</Link></li>
                                <li><Link to="/additem">Add item</Link></li>
                                <li><Link to="/items">Items</Link></li>
                                <li><Link to="/profile">Profile</Link></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div className="container body-content">
                    <div className="row">
                        {this.props.children}
                    </div>
                    <hr />
                    <footer>
                        <p>&copy; 2016 - ВВарехаузе</p>
                    </footer>
                </div>
            </div>
        );
    }
});

exports.Layout = Layout;