import React, { PropTypes, Component } from 'react'

export default class AddItemForm extends Component {
  name = ""
  desc = ""

  ChangeInputName(e){
    this.name = $(e.target).val()
  }

  ChangeInputDesc(e){
    this.desc = $(e.target).val()
  }

  onKeyDownName(e){
    if(e.keyCode == 13){
      $('#add-input-dis').focus()
    }
  }

  onKeyDownDesc(e){
    if(e.keyCode == 13){
      this.Send()
    }
  }

  Send(){
    this.props.send(this.name, this.desc)
    $('#add-input-name').val('')
    $('#add-input-dis').val('')
  }

  render() {
    return <div className="container body-content">
      <div className="row">
          <font size='4' color='#80b0aa'>Name</font>
          <input className='form-control' onKeyDown={::this.onKeyDownName} onChange={::this.ChangeInputName} id='add-input-name'/>
          <font size='4' color='#80b0aa'>Description</font>
          <input className='form-control' onKeyDown={::this.onKeyDownDesc} onChange={::this.ChangeInputDesc} id='add-input-dis'/>
          <br/>
          <button className='btn btn-success' onClick={::this.Send}>Add</button>
      </div>
    </div>
  }
}
