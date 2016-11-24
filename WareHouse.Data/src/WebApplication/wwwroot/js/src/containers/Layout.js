import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import URI from 'urijs'
import NavigationBar from '../components/layout/NavigationBar'
import BodyContent from '../components/layout/BodyContent'
import Footer from '../components/layout/Footer'
import * as aboutActions from '../actions/profile/about'

class Layout extends Component {
  componentDidMount(){
    let token = this.getTokenFromUri()

    if (!token)
        return

    window.localStorage.setItem("AuthToken", token)
    this.props.aboutActions.getUserInformation()
  }

  getTokenFromUri() {
      return new URI(window.location.href).search(true).token;
  }

  render(){
    const {nickname} = this.props.about
    const {getUserInformation} = this.props.aboutActions
    return <div>
      <NavigationBar nickname={nickname} getUserInformation={getUserInformation}/>
      <BodyContent content={this.props.children} />
      <Footer />
    </div>
  }
}

function mapStateToProps (state) {
  return {
    about: state.about
  }
}

function mapDispatchToProps(dispatch) {
  return {
    aboutActions: bindActionCreators(aboutActions, dispatch)
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(Layout)
