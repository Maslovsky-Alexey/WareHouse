import React, { PropTypes, Component } from 'react'


export default class About extends Component {
  componentWillMount(){
    this.props.getUserInformation();
  }

  render() {
    return <div>
            {
              this.props.errorMessage == null ?
                <div className="row">
                  <div className="col-sm-12">
                    <font size="3" color="#80b0aa"><b>{this.props.nickname}</b> you are {this.props.isEmployee ? 'Employee' : 'Client'}.</font>
                  </div>
                </div>
              : <div>
                  <div className="row">
                    <div className="col-sm-12">
                      <center>
                        <font size="7" color="#808080"><b>Error</b></font>
                      </center>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-sm-12">
                      <center>
                        <font size="5" color="#80b0aa">({this.props.errorMessage})</font>
                      </center>
                    </div>
                  </div>
            </div>
            }
    </div>
  }
}

About.propTypes = {
  name: PropTypes.string,
  nickname: PropTypes.string.isRequired,
  isEmployee: PropTypes.bool.isRequired,
  getUserInformation: PropTypes.func.isRequired,
  errorMessage: PropTypes.string
}
