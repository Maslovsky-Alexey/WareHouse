/// <reference path="body/listbody.js" />

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
                    <input className="form-control people-list-input" onKeyUp={this.changeSearchText} disabled={!this.props.active}/>
                </div>
                <ListBody values={this.items} click={this.click} hidden={!this.props.active} filter={this.filter}/>
            </div>
        );
    }

});