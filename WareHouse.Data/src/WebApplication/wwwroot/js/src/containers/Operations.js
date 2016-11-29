import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'

import * as adminActions from '../actions/profile/admin'
import * as orderActions from '../actions/orders/orders'
import * as supplyActions from '../actions/supplies/supplies'
import * as itemsActions from '../actions/items/items'

import '../style/components/operations/operations.css'

import FormOperations from '../components/operations/formOperations'

class Operations extends Component {
  componentDidMount(){
    this.props.adminActions.getClients()
    this.props.adminActions.getProviders()
    this.props.itemsActions.getItems()
  }

  addItem(provider, client, item, count, isSupply, success){
    if (isSupply){
      this.props.supplyActions.addSupply(item, count, provider, this.props.about.nickname, success)
    }
    else{
      this.props.orderActions.addOrder(item, count, client, this.props.about.nickname, success)
    }
  }

  render(){
    return <div className="row">
          <FormOperations clients={this.props.admin.clients} providers={this.props.admin.providers} items={this.props.items.items} send={::this.addItem} blocking={!this.props.ready}/>
     </div>
  }
}


function mapStateToProps (state) {
  return {
    admin: state.admin,
    about: state.about,
    items: state.items,
    ready: state.orders.ready && state.supplies.ready
  }
}

function mapDispatchToProps(dispatch) {
  return {
    adminActions: bindActionCreators(adminActions, dispatch),
    supplyActions: bindActionCreators(supplyActions, dispatch),
    orderActions: bindActionCreators(orderActions, dispatch),
    itemsActions: bindActionCreators(itemsActions, dispatch)
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(Operations)
