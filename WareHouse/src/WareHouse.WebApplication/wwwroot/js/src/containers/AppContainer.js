import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'

import * as notificationsActions from '../actions/notifications/notifications'

class AppContainer extends Component {
  lastTicks = 0
  polling = 0

  componentDidMount(){
      this.startPoll();
  }

  componentWillReceiveProps(nextProps){
    if (this.props.notifications !== nextProps.notifications){

      clearInterval(this.polling);
      console.debug(nextProps.notifications);

      if (nextProps.notifications.isFetching === false){
        this.startPoll();
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
    notificationsActions: bindActionCreators(notificationsActions, dispatch)
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(AppContainer)
