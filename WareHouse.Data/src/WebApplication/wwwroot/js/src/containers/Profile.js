import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'

import * as aboutActions from '../actions/profile/about'
import * as adminActions from '../actions/profile/admin'
import * as ordersActions from '../actions/orders/orders'
import * as suppliesActions from '../actions/supplies/supplies'

import About from '../components/profile/About'
import UserActions from '../components/profile/UserActions'
import GridView from '../components/others/gridView/GridView'

import generateOrderModel from '../components/others/gridView/models/orderModel'
import generateSupplyModel from '../components/others/gridView/models/supplyModel'

import BlockUi from 'react-block-ui';
import 'react-block-ui/style.css'

class Profile extends Component {
  componentDidMount(){
      this.props.suppliesActions.getSupplies();
      this.props.ordersActions.getOrders();
  }

  render() {
    const {name, nickname, isEmployee, errorMessage} = this.props.about
    const {getUserInformation} = this.props.aboutActions
    const orders = this.props.orders.items
    const supplies = this.props.supplies.items
    const {addClient, addEmployee} = this.props.adminActions

    return <BlockUi tag="div" blocking={!this.props.ready}>
      {
        errorMessage == null ?
          <div>
            <About name={name} nickname={nickname} isEmployee={isEmployee} getUserInformation={getUserInformation}/>
            {
              isEmployee ?
                <div>
                  <UserActions addClient={addClient} addEmployee={addEmployee}/>
                  Supplies
                  <GridView items={supplies} properties={generateSupplyModel(
                      (item) => {this.props.suppliesActions.confirmSupply(item.id)},
                      (item) => {this.props.suppliesActions.returnSupply(item.id)})}/>
                </div>
              : ""
            }
            Orders
            <GridView items={orders} properties={generateOrderModel(
                (item) => {this.props.ordersActions.confirmOrder(item.id)},
                (item) => {this.props.ordersActions.returnOrder(item.id)})}/>
          </div>
        :
          <ErrorMessage title={"Error"} message={errorMessage}/>
      }
    </BlockUi>
  }
}

function mapStateToProps (state) {
  return {
    about: state.about,
    orders: state.orders,
    supplies: state.supplies,
    admin: state.admin,
    ready: state.orders.ready && state.supplies.ready
  }
}

function mapDispatchToProps(dispatch) {
  return {
    aboutActions: bindActionCreators(aboutActions, dispatch),
    ordersActions: bindActionCreators(ordersActions, dispatch),
    suppliesActions: bindActionCreators(suppliesActions, dispatch),
    adminActions: bindActionCreators(adminActions, dispatch)
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(Profile)
