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
                "count: ",
                itemInfo.count
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

    nextPage: 0,
    prevPage: 0,

    getInitialState: function getInitialState() {
        getPageItems(this.onItemsGeted, this.nextPage);

        return { items: [] };
    },

    PrevPage: function PrevPage() {
        getPageItems(this.onItemsGeted, this.prevPage);
    },

    NextPage: function NextPage() {
        getPageItems(this.onItemsGeted, this.nextPage);
    },

    onItemsGeted: function onItemsGeted(data) {
        this.nextPage = data.nextPage;
        this.prevPage = data.prevPage;
        this.setState({ items: data.items });
    },

    render: function render() {
        return React.createElement(
            "div",
            { className: "app" },
            React.createElement(News, { data: this.state.items }),
            React.createElement(
                "div",
                { className: "col-xs-12" },
                React.createElement(
                    "nav",
                    { "aria-label": "..." },
                    React.createElement(
                        "ul",
                        { className: "pager" },
                        React.createElement(
                            "li",
                            null,
                            React.createElement(
                                "a",
                                { onClick: this.PrevPage },
                                "Previous"
                            )
                        ),
                        React.createElement(
                            "li",
                            null,
                            React.createElement(
                                "a",
                                { onClick: this.NextPage },
                                "Next"
                            )
                        )
                    )
                )
            )
        );
    }
});

ReactDOM.render(React.createElement(App, null), document.getElementById('root'));