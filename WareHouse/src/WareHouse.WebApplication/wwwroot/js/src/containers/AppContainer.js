import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'

import * as notificationsActions from '../actions/notifications/notifications'
import * as pollingEventManager from '../actions/pollingEventManager/pollingEventManager'

class AppContainer extends Component {
  lastTicks = 0
  polling = 0
  eventSender = []

  componentDidMount(){
    this.eventSender.push({ dataType: "Item", action: this.props.pollingEventManager.ChangeOrAddItem });
    this.eventSender.push({ dataType: "Supply", action: this.props.pollingEventManager.ChangeOrAddSupply });
    this.eventSender.push({ dataType: "Order", action: this.props.pollingEventManager.ChangeOrAddOrder });

    this.startPoll();
  }

  componentWillUnmount() {
      clearInterval(this.polling);
  }

  componentWillReceiveProps(nextProps){
    if (this.props.notifications !== nextProps.notifications){

      clearInterval(this.polling);

      this.analysisNotifications(nextProps);

      if (nextProps.notifications.isFetching === false){
        this.startPoll();
      }
    }
  }

  analysisNotifications(nextProps){
    for (let i = 0; i < nextProps.notifications.data.length; i++){

      if (this.lastTicks < nextProps.notifications.data[i].ticks){
        this.lastTicks = nextProps.notifications.data[i].ticks;
      }

      for (let j = 0; j < this.eventSender.length; j++){
        if (this.eventSender[j].dataType == nextProps.notifications.data[i].dataType){
           this.eventSender[j].action(nextProps.notifications.data[i].data)
        }
      }
    }
  }

  startPoll(){
    let getNotifications = this.props.notificationsActions.getNotifications;
    let lastTicks = this.lastTicks;

    clearInterval(this.polling);
    this.polling = setInterval(() => {
      getNotifications(lastTicks);
    }, 5000);
  }

  render(){
    return <div>{this.props.children}</div>
  }
}


function mapStateToProps (state) {
  return {
    notifications: state.notifications
  }
}

function mapDispatchToProps(dispatch) {
  return {
    notificationsActions: bindActionCreators(notificationsActions, dispatch),
    pollingEventManager: bindActionCreators(pollingEventManager, dispatch)
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(AppContainer)
