var React = require('react');
var ReactDom = require('react-dom');

var ListBody = require('./body/listbody.jsx');

var List = React.createClass({
    myTextInput: {},

    getInitialState: function () {       
        return { filter: "", items: [] };
    },

    search: function (text) {
        this.setState({ filter: text, items: this.state.items });
    },

    changeSearchText: function (e) {
        var value = $(e.target).val();
        this.search(value);
        this.props.changevalue("");
    },

    click: function (id, name) {
        this.myTextInput.val(name);
        this.props.changevalue(id);
    },

    add: function (e) {
        var value = this.myTextInput.val();
        this.myTextInput.val("");

        if (this.props.onadded)
            this.props.onadded(value);

        this.props.changevalue("");
    },

    componentWillReceiveProps: function(nextProps) {
        this.setState({ filter: this.state.filter, items: nextProps.items });
    },

    render: function () {
        var classname = "people-list " + this.props.side + (this.props.active ? " valid" : " invalid");
        this.side = this.props.side;

        return (
            <div className={classname}>
                <div className="people-list-head">
                    <div className="people-list-title">
                        {this.props.title}
                    </div>
                     <div className="input-group">
                        <input type="text" className="form-control people-list-input" onKeyUp={this.changeSearchText} disabled={!this.props.active} ref={(ref) => this.myTextInput = $(ref)}/>
                        <span className="input-group-btn">
                            <button className="btn btn-default btn-xs" type="button" onClick={this.add}>Add</button>
                        </span>
                     </div>
                </div>
                <ListBody.ListBody values={this.state.items} click={this.click} hidden={!this.props.active} filter={this.state.filter}/>
            </div>
        );
    }

});

exports.List = List;