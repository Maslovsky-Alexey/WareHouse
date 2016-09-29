/// <reference path="repositories/itemrepository.js" />
/// <reference path="../../../repositories/warehouseitemrepository.js" />

/// <reference path="elements/about.js" />
/// <reference path="elements/rating.js" />

var Items = React.createClass({
    nextPage: 0,
    prevPage: 0,
    itemRepos: new WarehouseItemsRepository(),
    isFirst: true,

    componentWillReceiveProps: function (nextProps) {
        this.nextPage = 0;
        this.itemRepos.getItems(this.onItemsGeted, this.nextPage, nextProps.filter);
    },

    getInitialState: function getInitialState() {
        this.itemRepos.getItems(this.onItemsGeted, this.nextPage, this.props.filter);
        return { items: [] };
    },

    PrevPage: function PrevPage() {
        this.itemRepos.getItems(this.onItemsGeted, this.prevPage, this.props.filter);
    },

    NextPage: function NextPage() {
        this.itemRepos.getItems(this.onItemsGeted, this.nextPage, this.props.filter);
    },

    onItemsGeted: function onItemsGeted(data) {
        
        this.nextPage = data.nextPage;
        this.prevPage = data.prevPage;
        if (this.isFirst)
            this.props.changeMaxMinCount(data.max, data.min);
        this.isFirst = false;
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