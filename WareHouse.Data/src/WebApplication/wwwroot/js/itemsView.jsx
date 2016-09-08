var my_news = [
    {
            name: "",
            price: 0,
            about: "",
            link: "#",

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

getItems(success);

function success(items) {
    my_news[0].info.name = items.name;

}


var About = React.createClass({
    render: function () {
        var itemInfo = this.props.itemInfo;
        return (
            <div className="caption">
                <h4 className="pull-right">${itemInfo.price}</h4>
                <h4><a href={itemInfo.link ? itemInfo.link : '#' }>{itemInfo.name ? itemInfo.name : 'Noname'}</a></h4>
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
                    <img src={item.imgSrc ? item.imgSrc : 'http://placehold.it/320x150'} alt="" />
                    <About itemInfo={item} />
                    <div className="ratings">
                        <p className="pull-right">{item.views ? item.views : 0} reviews</p>
                        <Ratings starscount={item.starscount ? item.starscount : 0} />
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
  getInitialState: function () {
    getItems((data) => {
        this.setState({ items: data });
    });

    return { items: my_news };
  },
  render: function() {
    return (
      <div className="app">
        <News data={this.state.items} />
      </div>
    );
  }
});

ReactDOM.render(
  <App />,
  document.getElementById('root')
);