
var React = require("react");
var ReactDom = require("react-dom");

var InputRange = require("react-input-range");

var FilterForm = React.createClass({
    values: { min: 0, max: 0 },
    isFirst: true,

    componentWillReceiveProps: function(props) {
        if (this.isFirst)
            this.values = { min: props.mincount, max: props.maxcount };

        this.isFirst = false;
    },

    getInitialState: function() {
        this.values = { min: this.props.mincount, max: this.props.maxcount };
        return { asc: true };
    },

    handleValuesChange: function(component, values) {
        this.values = values;
        this.forceUpdate();
    },

    changeOrder: function() {
        this.setState({ values: this.state.values, asc: !this.state.asc });
    },

    setOrderDown: function() {
        $("#down").addClass("active-arrow");
        $("#up").removeClass("active-arrow");
    },

    changeSearch: function(e) {
        var value = $(e.target).val();

        this.props.search(value);
    },

    filterComplete: function(e) {
        var filter = "?";

        var search = $("#search-name-input").val();

        var orderby = $("#property-order-selection").val();

        var isDown = $("#down").hasClass("active-arrow");

        this.props.search(search, this.values.min, this.values.max, orderby, isDown);
    },

    render: function() {
        var classNameUp = "fa fa-long-arrow-up " + (this.state.asc ? "active-arrow" : "");
        var classNameDown = "fa fa-long-arrow-down " + (!this.state.asc ? "active-arrow" : "");

        return (
            <div className="filter-form">
                <div className="row">
                    <div className="col-xs-7"></div>
                    <div className="col-xs-5">
                        <input className="form-control search-name-input" placeholder="Search" onKeyUp={
this.changeSearch} id="search-name-input"/>
                    </div>
                </div>

                <div className="row margin-top-5">
                    <div className="col-xs-2 padding-right-0">
                        <select className="form-control property-order-selection" id="property-order-selection">
                            <option>Name</option>
                            <option>Count</option>
                        </select>
                    </div>
                    <div className="col-xs-2 padding-left-0">
                        <i className={classNameUp} aria-hidden="true" onClick={this.changeOrder} id="up"></i>
                        <i className={classNameDown} aria-hidden="true" onClick={this.changeOrder} id="down"></i>
                    </div>
                    <div className="col-xs-5">
                        <InputRange className="input-range"
                                    maxValue={this.props.maxcount}
                                    minValue={this.props.mincount}
                                    value={this.values}
                                    onChange={this.handleValuesChange}
                                    labelSuffix={" count"}/>

                    </div>
                    <div className="col-xs-3">
                        <button className="form-control" onClick={this.filterComplete}>
                            Search
                        </button>
                    </div>
                </div>


                <div>

                </div>
            </div>
        );
    }
});

exports.FilterForm = FilterForm;