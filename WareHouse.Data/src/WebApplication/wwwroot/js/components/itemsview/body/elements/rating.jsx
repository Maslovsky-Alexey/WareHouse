var React = require('react');
var ReactDom = require('react-dom');

var Ratings = React.createClass({
    maxStars: 5,

    createStar: function(status, id){
        if (status){
            return (<span className="fa fa-star" key={id}></span>)
        }

        return (<span className="fa fa-star-o" key={id}></span>)
    },

    generateStarsRating: function(starscount){
        var stars = [];

        for (var i = 0; i < this.maxStars; i++)
            stars.push(this.createStar(i < starscount, i));

        return stars;
    },

    render: function () {
        return (<p>{this.generateStarsRating(this.props.starscount)}</p>)
    }
});

exports.Ratings = Ratings;
