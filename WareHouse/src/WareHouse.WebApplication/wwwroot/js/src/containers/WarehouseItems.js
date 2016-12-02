import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'

import * as pageActions from '../actions/warehouseItems/warehouseItems'

import Page from '../components/warehouseItems/page'
import FilterForm from '../components/warehouseItems/filterForm'

class WarehouseItems extends Component {
    filter = ""

    componentWillMount(){
      this.props.pageActions.getPageWarehouseItems(0)
    }

    search(searchName, minCount, maxCount, orderBy, orderAsc) {
        var filter = "?";

        if (searchName != null && searchName.length > 0)
            filter += "$property1=search&$filter1=" + searchName;


        if (minCount != null && maxCount != null && minCount.length > 0 && maxCount.length > 0)
            filter += "&$property2=count&$morethan2=" + (minCount - 1) + "&$lessthan2=" + (maxCount + 1);

        if (orderBy != null)
            filter += "&$orderby=" + orderBy;

        if (orderAsc != null && orderAsc == false)
            filter += "&$ordertype=descending";

        this.filter = filter

        this.props.pageActions.getPageWarehouseItems(0, this.filter)
    }

    render() {
      const changePage = this.props.pageActions.getPageWarehouseItems



      const nextPage = () => changePage(this.props.page.nextPage, this.filter)
      const prevPage = () => changePage(this.props.page.prevPage, this.filter)
      const {max, min} = this.props.page

      return <div>
        <FilterForm max={max} min={min} search={::this.search}/>
        <Page items={this.props.page.items} nextPage={nextPage} prevPage={prevPage}/>
      </div>
    }
}

function mapStateToProps (state) {
  return {
    page: state.page
  }
}

function mapDispatchToProps(dispatch) {
  return {
    pageActions: bindActionCreators(pageActions, dispatch)
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(WarehouseItems)
