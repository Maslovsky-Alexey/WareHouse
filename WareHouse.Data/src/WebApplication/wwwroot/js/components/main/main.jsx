/// <reference path="../loginview/loginview.js" />
/// <reference path="../itemsview/itemsview.js" />


ReactDOM.render((
    <Router>
        <Route path="/" component={LoginView} />
        <Route path="/itemsview/" component={ItemsView} />
    </Router>
), document.getElementById('root'));