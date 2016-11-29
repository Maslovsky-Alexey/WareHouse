import React, { PropTypes, Component } from 'react'

import PageItems from './pageItems'

export default class FilterForm extends Component {
  changeSearch(e) {
      var value = $(e.target).val()

      this.props.search(value)
  }

  filterComplete(e) {
      const filter = "?"
      const search = $("#search-name-input").val()
      const orderby = $("#property-order-selection").val()
      const isDown = $("#property-order-dir").val() === "Up"
      const max = $("#i-max").val()
      const min = $("#i-min").val()

      this.props.search(search, min, max, orderby, isDown)
  }

  render() {
    return <div className="filter-form">
        <div className="row">
            <div className="col-xs-7"></div>
            <div className="col-xs-5">
                <input className="form-control search-name-input" placeholder="Search" onKeyUp={::this.changeSearch} id="search-name-input"/>
            </div>
        </div>

        <div className="row margin-top-5">
            <div className="col-xs-2 padding-right-0">
                <select className="form-control property-order-selection" id="property-order-selection">
                    <option>Name</option>
                    <option>Count</option>
                </select>
            </div>
            <div className="col-xs-2 padding-left-0">
                <select className="form-control property-order-selection" id="property-order-dir">
                    <option>Up</option>
                    <option>Down</option>
                </select>
            </div>
            <div className="col-xs-5">
              Min({this.props.min}): <input className="form-control input-sm" id="i-min" />
              Max({this.props.max}): <input className="form-control input-sm" id="i-max" />
            </div>
            <div className="col-xs-3">
                <button className="form-control " onClick={::this.filterComplete}>
                    Search
                </button>
            </div>
        </div>
    </div>
  }

}
