import React, { PropTypes, Component } from 'react'

export default class FormOperations extends Component {
  provider = {}
  client = {}
  item = {}
  count = {}
  isSupply = true

  getValueFromOption(obj){
    return obj[obj.selectedIndex].id.substring(5)
  }

  click(){
    let provider = this.getValueFromOption(this.provider)
    let client = this.getValueFromOption(this.client)
    let item = this.getValueFromOption(this.item)
    let count = $(this.count).val()

    this.props.send(provider, client, item, count, this.isSupply == true)    
  }

  supply(e){
    this.isSupply = true
  }

  order(e){
    this.isSupply = false
  }

  render() {
    return <div>
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

          <input className="form-control item_count" placeholder="count" ref={(ref) => this.count = $(ref)[0]}/>
          <button className="btn btn-success btn-block btn-sm" onClick={::this.click}>Send</button>
      </div>
  }
}
