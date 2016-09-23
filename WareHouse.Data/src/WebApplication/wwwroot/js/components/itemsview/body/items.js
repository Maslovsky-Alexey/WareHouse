﻿"use strict";

/// <reference path="repositories/itemrepository.js" />

/// <reference path="elements/about.js" />
/// <reference path="elements/rating.js" />

var Items = React.createClass({
    displayName: "Items",

    nextPage: 0,
    prevPage: 0,
    itemRepos: new CreateItemRepository(),

    getInitialState: function getInitialState() {
        this.itemRepos.getPageItems(this.onItemsGeted, this.nextPage);

        return { items: [] };
    },

    PrevPage: function PrevPage() {
        this.itemRepos.getPageItems(this.onItemsGeted, this.prevPage);
    },

    NextPage: function NextPage() {
        this.itemRepos.getPageItems(this.onItemsGeted, this.nextPage);
    },

    onItemsGeted: function onItemsGeted(data) {
        this.nextPage = data.nextPage;
        this.prevPage = data.prevPage;
        this.setState({ items: data.items });
    },

    render: function render() {
        var data = this.state.items;
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
            null,
            React.createElement(
                "div",
                { className: "news" },
                newsTemplate
            ),
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