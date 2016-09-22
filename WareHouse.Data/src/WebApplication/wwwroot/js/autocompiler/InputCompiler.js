'use strict';

var InputCompiler = React.createClass({
    displayName: 'InputCompiler',


    getInitialState: function getInitialState() {
        return { viewItems: [] };
    },

    click: function click(e) {
        $(e.target).parent().parent().find(".item_name").val($(e.target).text());
        this.setState({ viewItems: [] });

        if (this.props.valuechanged) this.props.valuechanged(this.props.items[$(e.target).attr('id')]);
    },

    onchange: function onchange(e) {
        var data = [];
        var value = $(e.target).val();

        if (value.replace(' ', '') == '') data = []; else data = this.props.items.filter(function (item, index) {
            return item.name.toLowerCase().includes(value.toLowerCase());
        });

        this.setState({ viewItems: data });

        if (this.props.valuechanged) this.props.valuechanged(value);
    },

    render: function render() {

        var click = this.click;
        var items = this.state.viewItems.map(function (item, index) {
            return React.createElement(
                'div',
                { className: 'compiler-item', key: index, onClick: click, id: index },
                item.name
            );
        });

        return React.createElement(
            'div',
            { className: 'InputCompiler' },
            React.createElement('input', { className: 'form-control item_name', placeholder: 'item name', onChange: this.onchange }),
            React.createElement(
                'div',
                { className: 'compiler-list-items' },
                items
            )
        );
    }
});