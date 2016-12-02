import React, { PropTypes, Component } from 'react'

export default class List extends Component {
  myTextInput = {}

  click(e){
    let index = this.myTextInput.selectedIndex
    let id = this.myTextInput[index].id

    this.props.changevalue(id.substring(4))
  }

  render() {
    let classname = "people-list " + this.props.side + (this.props.active ? " valid" : " invalid")
    this.side = this.props.side

    if (this.props.items.length > 0)
        this.props.changevalue(this.props.items[0].id)

    return <div className={classname}>
              <div className="people-list-head">
                  <div className="people-list-title">
                      {this.props.title}
                  </div>
                  <div className="input-group">
                      <select className="form-control select-list-item" ref={(ref) => this.myTextInput = $(ref)[0]} onChange={::this.click}>
                        {
                          this.props.items.map(function(item, index){
                            return <option active={index == 0} key={index} id={'opt-' + item.id}>{item.name}</option>
                          })
                        }
                      </select>
                  </div>
              </div>
          </div>
  }
}
