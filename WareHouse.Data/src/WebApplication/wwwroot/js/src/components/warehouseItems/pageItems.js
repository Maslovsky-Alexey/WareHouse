import React, { PropTypes, Component } from 'react'
import '../../style/components/warehouseItems/pageItems.css'


export default class Items extends Component {
  componentWillMount(){

  }

  render() {
    let data = this.props.items
    let newsTemplate = null

    if (data != null){
      let newsTemplate = data.map(function(item, index) {
          return (
              <div className="col-sm-4 col-lg-4 col-md-4" key={index }>
                  <div className="thumbnail">
                      <img src={item.imgSrc ? item.imgSrc : "http://placehold.it/320x150"} alt=""/>
                      <div className="caption">
                          <h4 className="pull-right">count: {item.count}</h4>
                          <h4>
                              <a href={item.link ? item.link : "#" }>{item.name ? item.name : "Noname"}</a>
                          </h4>
                          <p>{item.description}</p>
                      </div>
                  </div>
              </div>
          );
      });

      return <div>{newsTemplate}</div>
    }

  }
}
