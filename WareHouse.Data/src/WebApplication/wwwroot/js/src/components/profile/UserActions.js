import React, { PropTypes, Component } from 'react'

export default class UserActions extends Component {
    clientName = ""
    employeeName = ""

    clientNameChange(e){
      this.clientName = $(e.target).val()
    }

    employeeNameChange(e){
      this.employeeName = $(e.target).val()
    }

    registerClient(){
      this.props.addClient(this.clientName)
    }
    registerEmployee(){
      this.props.addEmployee(this.employeeName)
    }
    render() {
      return <div className="row">
          Client name <input id='client-name' onChange={::this.clientNameChange}/>
        <button className="btn btn-sm" onClick={::this.registerClient}>Add</button>
          <br/>

          Employee name <input id='employee-name' onChange={::this.employeeNameChange}/>
        <button className="btn btn-sm" onClick={::this.registerEmployee}>Add</button>
          <br/>
      </div>
    }
}
