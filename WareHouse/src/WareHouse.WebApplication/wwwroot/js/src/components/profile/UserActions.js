import React, { PropTypes, Component } from 'react'

export default class UserActions extends Component {
    userName = ""

    userNameChange(e){
      this.userName = $(e.target).val();
    }

    registerClient(){
      this.props.addClient(this.userName);
    }

    registerEmployee(){
      this.props.addEmployee(this.userName);
    }

    addProvider(){
      this.props.addProvider(this.userName);
    }

    render() {
      return <div className="row">
        <p>User name</p><input id='client-name' onChange={::this.userNameChange}/>
        <button className="btn btn-sm" onClick={::this.registerClient}>is client</button>
        <button className="btn btn-sm" onClick={::this.registerEmployee}>is employee</button>
        <button className="btn btn-sm" onClick={::this.addProvider}>add provider</button>
      </div>
    }
}
