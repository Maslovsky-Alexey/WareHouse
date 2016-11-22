
"use strict";

/// <reference path="../loginview/loginview.js" />
/// <reference path="../itemsview/itemsview.js" />


ReactDOM.render(React.createElement(
        ReactRouter.Router,
        null,
        React.createElement(ReactRouter.Route, { path: "/", component: LoginView }),
        React.createElement(ReactRouter.Route, { path: "/itemsview/", component: ItemsView })
    ),
    document.getElementById("root"));