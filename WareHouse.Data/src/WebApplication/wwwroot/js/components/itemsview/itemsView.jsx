﻿/// <reference path="components/itemsview/body/items.js" />
/// <reference path="../react-input-range/react-input-range.min.js" />
/// <reference path="filterform/filterform.js" />

var ItemsView = React.createClass({

    getInitialState: function getInitialState() {
        return { filter: "", maxCount: 1, minCount: 0 };
    },

    Search: function(searchName, minCount, maxCount, orderBy, orderAsc){
        var filter = "?";

        if (searchName != null && searchName.length > 0)
            filter += "$property1=name&$filter1=" + searchName;

        if (minCount != null && maxCount != null)
            filter += "&$property2=count&$morethan2=" + (minCount - 1) + "&$lessthan2=" + (maxCount + 1);

        if (orderBy != null)
            filter += "&$orderby=" + orderBy;

        if (orderAsc != null && orderAsc == false)
            filter += "&$ordertype=descending";

        this.setState({ filter: filter });
    },

    changeMaxMinCount: function (max, min) {
        if (this.state.maxCount != max || this.state.minCount != min)
            this.setState({ filter: this.state.filter, maxCount: max, minCount: min });
    },

    render: function () {

        return (
            <div className="app">   
                <FilterForm search={this.Search} maxcount={this.state.maxCount} mincount={this.state.minCount}/>          
                <Items filter={this.state.filter} changeMaxMinCount={this.changeMaxMinCount}/>
            </div>
        );
    }
});

ReactDOM.render(<ItemsView />, document.getElementById('root'));