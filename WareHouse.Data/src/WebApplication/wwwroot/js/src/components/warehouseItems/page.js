import React, { PropTypes, Component } from 'react'

import PageItems from './pageItems'

export default class Page extends Component {
  componentWillMount(){

  }

  render() {
    return <div>
        <div className="news">
            <PageItems items={this.props.items}/>
        </div>
        <div className="col-xs-12">
            <nav aria-label="...">
                <ul className="pager">
                    <li>
                        <a onClick={this.props.prevPage}>Previous</a>
                    </li>
                    <li>
                        <a onClick={this.props.nextPage}>Next</a>
                    </li>
                </ul>
            </nav>
        </div>
    </div>
  }

}
