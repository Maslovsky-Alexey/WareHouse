import React, { PropTypes, Component } from 'react'

export default class BodyContent extends Component {
  render() {
    return <div className="container body-content">
      <div className="row">
          {this.props.content}
      </div>
    </div>
  }
}

BodyContent.propTypes = {
  content: PropTypes.element.isRequired,
}
