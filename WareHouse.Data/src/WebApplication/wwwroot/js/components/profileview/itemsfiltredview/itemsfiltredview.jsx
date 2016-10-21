
var React = require("react");
var ReactDom = require("react-dom");

var ItemsFiltredView = React.createClass({
    getInitialState: function getInitialState() {
        return {};
    },


    render: function () {

        var template = this.props.items.map(
            (item, i) => {

                var result = this.props.properties.map(
                    (property, j) => {

                        var result;

                        if (property.type === 'text')
                            result = (
                                <i className="profile-items-prop">
                                    <b>{property.caption}:</b>
                                    <i>{property.get(item)}</i>
                                </i>
                            );
                        if (property.type === 'button')
                            result = (
                                <button onClick={() => property.onClick(item)}>{property.caption}</button>
                            );

                        return result;
                    }
                );

                return (<div className="col-xs-12 profile-items-row" key={i}>{result}</div>);
            }
        );

        return (
            <div className="row profile-items-view">
                {template}
            </div>
        );
    }
});

exports.ItemsFiltredView = ItemsFiltredView;