"use strict";

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
        }
        return stars;
    },

    render: function render() {
        return React.createElement(
            "p",
            null,
            this.generateStarsRating(this.props.starscount)
        );
    }
});