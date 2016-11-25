import React, { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'

import * as itemActions from '../actions/additem/items'

import AddItemForm from '../components/addItem/addItemForm'

class AddItem extends Component {
  componentDidMount(){

  }

  render(){
    const {addItem} = this.props.itemActions
    return <AddItemForm send={addItem}/>
  }
}


function mapStateToProps (state) {
  return {
  }
}

function mapDispatchToProps(dispatch) {
  return {
    itemActions: bindActionCreators(itemActions, dispatch)
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(AddItem)
