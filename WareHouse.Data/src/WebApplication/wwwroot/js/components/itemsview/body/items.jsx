/// <reference path="repositories/itemrepository.js" />

/// <reference path="elements/about.js" />
/// <reference path="elements/rating.js" />

var Items = React.createClass({
    nextPage: 0,
    prevPage: 0,
    itemRepos: new CreateItemRepository(),

    getInitialState: function () {
        this.itemRepos.getPageItems(this.onItemsGeted, this.nextPage);

        return { items: [] };
    },

    PrevPage: function () {
        this.itemRepos.getPageItems(this.onItemsGeted, this.prevPage);
    },

    NextPage: function () {
        this.itemRepos.getPageItems(this.onItemsGeted, this.nextPage);
    },

    onItemsGeted: function (data) {
        this.nextPage = data.nextPage;
        this.prevPage = data.prevPage;
        this.setState({ items: data.items });
    },

    render: function () {
        var data = this.state.items;
        var newsTemplate = data.map(function (item, index) {
            return (
                <div className="col-sm-4 col-lg-4 col-md-4" key={index }>
                    <div className="thumbnail">
                        <img src={item.imgSrc ? item.imgSrc : 'http://placehold.it/320x150'} alt="" />
                        <About itemInfo={item } />
                        <div className="ratings">
                            <p className="pull-right">{item.views ? item.views : 0} reviews</p>
                            <Ratings starscount={item.starscount ? item.starscount : 0 } />
                        </div>
                    </div>
                </div>
            )
        })

        return (
            <div>
                <div className="news">
                    {newsTemplate}
                </div>
                <div className="col-xs-12">
                    <nav aria-label="...">
                        <ul className="pager">
                        <li><a onClick={this.PrevPage }>Previous</a></li>
                        <li><a onClick={this.NextPage }>Next</a></li>
                        </ul>
                    </nav>
                </div>
            </div>
        );
    }
});