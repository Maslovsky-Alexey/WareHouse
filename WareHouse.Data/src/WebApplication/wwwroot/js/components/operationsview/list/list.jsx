var React = require('react');
var ReactDom = require('react-dom');

var ListBody = require('./body/listbody.jsx');

var List = React.createClass({
    items: [],
    filter: "",

    search: function (text) {
        this.filter = text;

        this.forceUpdate();
    },

    changeSearchText: function (e) {
        var value = $(e.target).val();
        this.search(value);
        this.props.changevalue(value);
    },

    click: function (e) {
        var value = $(e.target).text();

        $(e.target).parent().parent().find("input").val(value);
        this.search(value);
        this.props.changevalue(value);
    },

    add: function(e){
        var value = $(e.target).parent().parent().find("input").val();
      
        this.props.items.push(value);

        if (this.props.onadded)
            this.props.onadded(value);

        this.props.changevalue(value);

        this.forceUpdate();
    },

    render: function () {
        this.items = this.props.items;

        var classname = "people-list " + this.props.side + (this.props.active ? " valid" : " invalid");
        this.side = this.props.side;

        return (
            <div className={classname}>
                <div className="people-list-head">
                    <div className="people-list-title">
                        {this.props.title}
                    </div>
                     <div className="input-group">
                        <input type="text" className="form-control people-list-input" onKeyUp={this.changeSearchText} disabled={!this.props.active} />
                        <span className="input-group-btn">
                            <button className="btn btn-default btn-xs" type="button" onClick={this.add}>Add</button>
                        </span>
                     </div>
                </div>
                <ListBody.ListBody values={this.items} click={this.click} hidden={!this.props.active} filter={this.filter}/>
            </div>
        );
    }

});

exports.List = List;