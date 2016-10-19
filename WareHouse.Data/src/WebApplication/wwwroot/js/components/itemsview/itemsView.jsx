var React = require('react');
var ReactDom = require('react-dom');

var Items = require('./body/items.jsx');
var FilterForm = require('./filterform/filterform.jsx');

var ItemsView = React.createClass({

    getInitialState: function getInitialState() {
        return { filter: "", maxCount: 1, minCount: 0 };
    },

    Search: function(searchName, minCount, maxCount, orderBy, orderAsc){
        var filter = "?";

        if (searchName != null && searchName.length > 0)
            filter += "$property1=item.name&$filter1=" + searchName;


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
                <FilterForm.FilterForm search={this.Search} maxcount={this.state.maxCount} mincount={this.state.minCount}/>          
                <Items.Items filter={this.state.filter} changeMaxMinCount={this.changeMaxMinCount}/>
            </div>
        );
    }
});

exports.ItemsView = ItemsView;