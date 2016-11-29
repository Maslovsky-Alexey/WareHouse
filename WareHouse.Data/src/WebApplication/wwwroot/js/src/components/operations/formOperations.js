import React, { PropTypes, Component } from 'react';

import ValidationInput from '../others/validationInput/validationInput';
import GetValidationRules from '../../validators/Validator';

import BlockUi from 'react-block-ui';
import 'react-block-ui/style.css'

const validator = GetValidationRules();

export default class FormOperations extends Component {
  provider = {}
  client = {}
  item = {}
  count = 0
  isSupply = true
  isValid = false

  getValueFromOption(obj){
    return obj[obj.selectedIndex].id.substring(5)
  }

  click(){
    if (this.isValid == false){
      return;
    }

    let provider = this.getValueFromOption(this.provider);
    let client = this.getValueFromOption(this.client);
    let item = this.getValueFromOption(this.item);

    this.props.send(provider, client, item, this.count, this.isSupply == true, this.success);
  }

  supply(e){
    this.isSupply = true;
  }

  order(e){
    this.isSupply = false;
  }

  changeValid(isValid, text){
    this.isValid = isValid;
    this.count = text;
  }

  success(){
      $("#input-count-form-operation").val('');
  }

  render(){
    return <BlockUi tag="div" blocking={this.props.blocking}>
          <label className="radio-inline radioleft">
              <input type="radio" name="inlineRadioOptions" id="supply" value="supply" onChange={::this.supply}/> Supply
          </label>
          <label className="radio-inline radioright">
              <input type="radio" name="inlineRadioOptions" id="order" value="order" onChange={::this.order}/> Order
          </label>

          Providers
          <select className="form-control select-list-item" ref={(ref) => this.provider = $(ref)[0]} >
            {
              this.props.providers.map(function(item, index){
                return <option active={index == 0} key={index} id={'opt1-' + item.id}>{item.name}</option>
              })
            }
          </select>

          Clients
          <select className="form-control select-list-item" ref={(ref) => this.client = $(ref)[0]}>
            {
              this.props.clients.map(function(item, index){
                return <option active={index == 0} key={index} id={'opt2-' + item.id}>{item.name}</option>
              })
            }
          </select>

          Items
          <select className="form-control select-list-item" ref={(ref) => this.item = $(ref)[0]}>
            {
              this.props.items.map(function(item, index){
                return <option active={index == 0} key={index} id={'opt3-' + item.id}>{item.name}</option>
              })
            }
          </select>

          <ValidationInput rule={validator.validateCount} changeValid={::this.changeValid} id="input-count-form-operation"/>

          <button className="btn btn-success btn-block btn-sm" onClick={::this.click}>Send</button>
       </BlockUi>
  }
}
