/// <reference path="components/itemsview/body/items.js" />

var ItemsView = React.createClass({   
    render: function () {
        return (
            <div className="app">
                <Items />
            </div>
        );
    }
});

ReactDOM.render(<ItemsView />, document.getElementById('root'));