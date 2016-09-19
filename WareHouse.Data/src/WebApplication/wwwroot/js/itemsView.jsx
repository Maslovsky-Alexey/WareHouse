var About = React.createClass({
    render: function () {
        var itemInfo = this.props.itemInfo;
        return (
            <div className="caption">
                <h4 className="pull-right">count: {itemInfo.count}</h4>
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
    nextPage: 0,
    prevPage: 0,


    getInitialState: function () {
        getPageItems(this.onItemsGeted, this.nextPage);

        return { items: [] };
    },

    PrevPage: function(){
        getPageItems(this.onItemsGeted, this.prevPage);
    },

    NextPage: function () {
        getPageItems(this.onItemsGeted, this.nextPage);
    },

    onItemsGeted: function (data) {
        this.nextPage = data.nextPage;
        this.prevPage = data.prevPage;
        this.setState({ items: data.items });
    },

    render: function() {
    return (
        <div className="app">
        <News data={this.state.items} />
        <div className="col-xs-12">
            <nav aria-label="...">
                <ul className="pager">
                <li><a onClick={this.PrevPage}>Previous</a></li>
                <li><a onClick={this.NextPage}>Next</a></li>
                </ul>
            </nav>
        </div>

        </div>
    );
    }
});

ReactDOM.render(
  <App />,
  document.getElementById('root')
);