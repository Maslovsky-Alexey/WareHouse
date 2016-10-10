var React = require('react');
var ReactDom = require('react-dom');
var ReactRouter = require('react-router');

var LoginView = require('../loginview/loginview.jsx');
var ItemsView = require('../itemsview/itemsview.jsx');
var OperationsView = require('../operationsview/operationsview.jsx');
var AddItemsView = require('../additemsview/additemsview.jsx');
var ProfileView = require('../profileview/profileview.jsx');

ReactDOM.render((
    <ReactRouter.Router>
        <ReactRouter.Route path="/" component={LoginView.LoginView} />
        <ReactRouter.Route path="/items" component={ItemsView.ItemsView} />
        <ReactRouter.Route path="/operations" component={OperationsView.OperationsView} />
        <ReactRouter.Route path="/additem" component={AddItemsView.AddItemsView} />
        <ReactRouter.Route path="/profile" component={ProfileView.ProfileView} />
    </ReactRouter.Router>
), document.getElementById('root'));



