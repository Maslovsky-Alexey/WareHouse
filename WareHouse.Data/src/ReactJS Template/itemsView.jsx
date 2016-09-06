var my_news = [
    {
        info: {
            name: "Apple",
            price: 32,
            about: "This is apple. Eat it!",
            link: "#"
        },

        starscount: 4,
        views: 13,
        imgSrc: "http://placehold.it/320x150",

    },
    {
        info: {
            name: "Juce",
            price: 111,
            about: "This is Juce. Drink it!",
            link: "#"
        },

        starscount: 5,
        views: 55,
        imgSrc: "http://placehold.it/320x150",

    },
];


var About = React.createClass({
    render: function () {
        var itemInfo = this.props.itemInfo;
        return (
            <div className="caption">
                <h4 className="pull-right">${itemInfo.price}</h4>
                <h4><a href={itemInfo.link }>{itemInfo.name}</a></h4>
                <p>{itemInfo.about}</p>
            </div>
            )
    }
});

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

var News = React.createClass({
  render: function() {
    var data = this.props.data;
    var newsTemplate = data.map(function(item, index) {
      return (
            <div className="col-sm-4 col-lg-4 col-md-4" key={index}>
                <div className="thumbnail">
                    <img src={item.imgSrc} alt=""/>
                    <About itemInfo={item.info}/>
                    <div className="ratings">
                        <p className="pull-right">{item.views} reviews</p>
                        <Ratings starscount={item.starscount}/>
                    </div>
                </div>
            </div>
      )
    })

    return (
      <div className="news">{newsTemplate}
      </div>
    );
  }
});

var App = React.createClass({
  render: function() {
    return (
      <div className="app">        
        <News data={my_news} />
      </div>
    );
  }
});

ReactDOM.render(
  <App />,
  document.getElementById('root')
);