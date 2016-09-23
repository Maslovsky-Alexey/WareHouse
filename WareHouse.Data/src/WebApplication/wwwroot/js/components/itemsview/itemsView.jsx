/// <reference path="components/itemsview/body/items.js" />
/// <reference path="../react-input-range/react-input-range.min.js" />

//TODO: РАЗБИТЬ НА ОТДЕЛЬНЫЕ ФАЙЛЫ И ПОПРАВИТЬ ВЕРСТКУ

var ItemsView = React.createClass({

    getInitialState: function () {
        return { values: { min: 2, max: 6 }, asc: true };
    },

    handleValuesChange: function (component, values) {
        this.setState({
            values: values,
        });
    },

    changeOrder: function () {
        this.setState({ values: this.state.values, asc: !this.state.asc });
    },

    setOrderDown: function () {
        $("#down").addClass("active-arrow");
        $("#up").removeClass("active-arrow");
    },

    render: function () {
        var classNameUp = "fa fa-long-arrow-up " + (this.state.asc ? "active-arrow" : "");
        var classNameDown = "fa fa-long-arrow-down " + (!this.state.asc ? "active-arrow" : "");

        return (    
            <div className="app">
                <div className="row">
                    <div className="col-xs-7">
                          <input className="form-control search-name-input" />
                    </div>
                    <div className="col-xs-2">
                        <select className="form-control">
                            <option>Name</option>
                            <option>Count</option>
                        </select>
                    </div>
                    <div className="col-xs-1">
                        <i className={classNameUp} aria-hidden="true" onClick={this.changeOrder} id="up"></i>
                        <i className={classNameDown} aria-hidden="true" onClick={this.changeOrder} id="down"></i>
                    </div>
                </div>

                <button className="form-control">
                    Search
                </button>

                <div>
                <InputRange className="input-range"
                            maxValue={20}
                            minValue={0}
                            value={this.state.values}
                            onChange={this.handleValuesChange.bind(this)}
                            labelSuffix={" count"} />
                </div>
                <Items />

            </div>
        );
    }
});

ReactDOM.render(<ItemsView />, document.getElementById('root'));