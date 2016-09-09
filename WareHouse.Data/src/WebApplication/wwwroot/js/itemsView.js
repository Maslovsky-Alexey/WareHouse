"use strict";

var About = React.createClass({
    displayName: "About",

    render: function render() {
        var itemInfo = this.props.itemInfo;
        return React.createElement(
            "div",
            { className: "caption" },
            React.createElement(
                "h4",
                { className: "pull-right" },
                "$",
                itemInfo.price
            ),
            React.createElement(
                "h4",
                null,
                React.createElement(
                    "a",
                    { href: itemInfo.link ? itemInfo.link : '#' },
                    itemInfo.name ? itemInfo.name : 'Noname'
                )
            ),
            React.createElement(
                "p",
                null,
                itemInfo.about
            )
        );
    }
});

var Ratings = React.createClass({
    displayName: "Ratings",

    maxStars: 5,

    createStar: function createStar(status, id) {
        if (status) {
            return React.createElement("span", { className: "fa fa-star", key: id });
        }

        return React.createElement("span", { className: "fa fa-star-o", key: id });
    },

    generateStarsRating: function generateStarsRating(starscount) {
        var stars = [];

        for (var i = 0; i < this.maxStars; i++) {
            stars.push(this.createStar(i < starscount, i));
        } return stars;
    },

    render: function render() {
        return React.createElement(
            "p",
            null,
            this.generateStarsRating(this.props.starscount)
        );
    }
});

var News = React.createClass({
    displayName: "News",

    render: function render() {
        var data = this.props.data;
        var newsTemplate = data.map(function (item, index) {
            return React.createElement(
                "div",
                { className: "col-sm-4 col-lg-4 col-md-4", key: index },
                React.createElement(
                    "div",
                    { className: "thumbnail" },
                    React.createElement("img", { src: item.imgSrc ? item.imgSrc : 'http://placehold.it/320x150', alt: "" }),
                    React.createElement(About, { itemInfo: item }),
                    React.createElement(
                        "div",
                        { className: "ratings" },
                        React.createElement(
                            "p",
                            { className: "pull-right" },
                            item.views ? item.views : 0,
                            " reviews"
                        ),
                        React.createElement(Ratings, { starscount: item.starscount ? item.starscount : 0 })
                    )
                )
            );
        });

        return React.createElement(
            "div",
            { className: "news" },
            newsTemplate
        );
    }
});

var App = React.createClass({
    displayName: "App",

    getInitialState: function getInitialState() {
        var _this = this;

        getItems(function (data) {
            _this.setState({ items: data });
        });

        return { items: [] };
    },
    render: function render() {
        return React.createElement(
            "div",
            { className: "app" },
            React.createElement(News, { data: this.state.items })
        );
    }
});

ReactDOM.render(React.createElement(App, null), document.getElementById('root'));