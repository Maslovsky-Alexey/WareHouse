import React, { PropTypes, Component } from 'react'

import ValidationInput from '../others/validationInput/validationInput';
import GetValidationRules from '../../validators/Validator';

const validator = GetValidationRules();

export default class AddItemForm extends Component {
  name = ""
  desc = ""
  isValidDesc = false
  isValidName = false

  changeValidName(isValid, text){
      this.name = text;
      this.isValidName = isValid;
  }

  changeValidDesc(isValid, text){
      this.desc = text;
      this.isValidDesc = isValid;
  }

  Send(){
      if (this.isValidName == false || this.isValidDesc == false){
        return;
      }

      this.props.send(this.name, this.desc);
      $('#add-input-name input').val('');
      $('#add-input-dis input').val('');
  }

  render() {
    return <div className="container body-content">
      <div className="row">
          <font size='4' color='#80b0aa'>Name</font>
          <ValidationInput rule={validator.itemName} changeValid={::this.changeValidName} id='add-input-name'/>

          <font size='4' color='#80b0aa'>Description</font>
          <ValidationInput rule={validator.description} changeValid={::this.changeValidDesc} id='add-input-dis'/>

          <br/>
          <button className='btn btn-success' onClick={::this.Send}>Add</button>
      </div>
    </div>
  }
}
