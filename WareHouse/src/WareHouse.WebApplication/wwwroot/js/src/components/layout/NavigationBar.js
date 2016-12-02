import React, { PropTypes, Component } from 'react'
import {Link} from 'react-router'
import AuthAPI from '../../helpers/AuthAPI'

export default class NavigationBar extends Component {
  componentWillMount(){
    this.props.getUserInformation();
  }

  redirect(){
    new AuthAPI().login()
  }

  render() {
    return <div className="navbar navbar-inverse">
            <div className="container">
                <div className="navbar-header">
                    <Link className="navbar-brand" to="/">ВВарехаузе</Link>
                </div>
                <div className="navbar-collapse collapse">
                    <ul className="nav navbar-nav">
                        <li>
                            <Link to="/operations">New operation</Link>
                        </li>
                        <li>
                            <Link to="/additem">Add item</Link>
                        </li>
                        <li>
                            <Link to="/items">Items</Link>
                        </li>
                        <li>
                          <button className="btn btn-link" onClick={this.redirect}>Login</button>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
  }
}
