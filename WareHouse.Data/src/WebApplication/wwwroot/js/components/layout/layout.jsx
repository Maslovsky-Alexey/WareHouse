var React = require("react");
var ReactDom = require("react-dom");
var Link = require("react-router").Link;
var Redirecter = require("../../helpers/redirecter.js").Redirecter;

var Layout = React.createClass({
    getInitialState: function getInitialState() {

        return {};
    },

    logout: function() {
        window.localStorage.clear();
        Redirecter.redirect("");
    },

    render: function() {
        return (
            <div className="InputCompiler">
                <div className="navbar navbar-inverse navbar-fixed-top">
                    <div className="container">
                        <div className="navbar-header">
                            <a className="navbar-brand">ВВарехаузе</a>
                        </div>
                        <div className="navbar-collapse collapse">
                            <ul className="nav navbar-nav">
                                <li>
                                    <Link to="/operations">New operation</Link>
                                </li>
                                <li>
                                    <Link to="/additem">Add item</Link>
                                </li>
                                <li>
                                    <Link to="/items">Items</Link>
                                </li>
                                <li>
                                    <Link to="/profile">Profile</Link>
                                </li>
                                <li>
                                    <button className="form-control btn-link" onClick={this.logout}>Logout</button>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div className="container body-content">
                    <div className="row">
                        {this.props.children}
                    </div>
                    <hr/>
                    <footer>
                        <p>&copy; 2016 - ВВарехаузе</p>
                    </footer>
                </div>
            </div>
        );
    }
});

exports.Layout = Layout;