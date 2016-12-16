import React, { PropTypes, Component } from 'react'

import ValidationInput from '../others/validationInput/validationInput';
import GetValidationRules from '../../validators/Validator';

import BlockUi from 'react-block-ui';
import 'react-block-ui/style.css'

const validator = GetValidationRules();

export default class AddItemForm extends Component {
  name = ""
  desc = ""
  isValidDesc = false
  isValidName = false
  b64 = ""

  componentDidMount(){
    var r = this;
    document.getElementById('file').onchange = function (e) {
      let reader = new FileReader();
       reader.onload = function (e) {
         r.b64 = e.target.result;
       }
      reader.readAsDataURL(e.target.files[0]);
    };
  }

  changeValidName(isValid, text){
      this.name = text;
      this.isValidName = isValid;
  }

  changeValidDesc(isValid, text){
      this.desc = text;
      this.isValidDesc = isValid;
  }

  Send(){
      if (this.isValidName == false || this.isValidDesc == false || this.b64 == ""){
        return;
      }

      this.props.send(this.name, this.desc, this.b64, this.success);
  }

  success(){
    $('#add-input-name').val('');
    $('#add-input-dis').val('');
  }

  render() {
    return <BlockUi blocking={this.props.blocking}>
      <div className="container body-content">
        <div className="row">
            <font size='4' color='#80b0aa'>Name</font>
            <ValidationInput rule={validator.itemName} changeValid={::this.changeValidName} id='add-input-name'/>

            <font size='4' color='#80b0aa'>Description</font>
            <ValidationInput rule={validator.description} changeValid={::this.changeValidDesc} id='add-input-dis'/>

            <br/>
            <input type="file" id="file" />
            <button className='btn btn-success' onClick={::this.Send}>Add</button>
        </div>
    </div>
</BlockUi>
  }
}
