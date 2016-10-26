var React = require("react");
var ReactDom = require("react-dom");
var ReactRouter = require("react-router");

var LoginView = require("../loginview/loginview.jsx").LoginView;
var ItemsView = require("../itemsview/itemsview.jsx").ItemsView;
var OperationsView = require("../operationsview/operationsview.jsx").OperationsView;
var AddItemsView = require("../additemsview/additemsview.jsx").AddItemsView;
var ProfileView = require("../profileview/profileview.jsx").ProfileView;
var Layout = require("../layout/layout.jsx").Layout;
var ConcreteItemView = require("../concreteitemview/concreteitemview.jsx").ConcreteItemView;




ReactDOM.render((
        <ReactRouter.Router>
            <ReactRouter.Route component={Layout}>
                <ReactRouter.Route path="/" components={LoginView}/>
                <ReactRouter.Route path="/items" component={ItemsView}/>
                <ReactRouter.Route path="/operations" component={OperationsView}/>
                <ReactRouter.Route path="/additem" component={AddItemsView}/>
                <ReactRouter.Route path="/profile" component={ProfileView}/>
                <ReactRouter.Route path="/profile/:name" component={ProfileView}/>
                <ReactRouter.Route path="/item/:id" component={ConcreteItemView}/>
            </ReactRouter.Route>
        </ReactRouter.Router>
    ),
    document.getElementById("root"));