import React, { PropTypes, Component } from 'react'
import '../../../style/components/others/gridView/gridView.css'

export default class GridView extends Component {
    render() {
      let template = this.props.items.map(
          (item, i) => {

              let result = this.props.properties.map(
                  (property, j) => {

                      let result;

                      if (property.type === 'text'){
                        result = (
                            <i className="profile-items-prop-text">
                                <b>{property.caption}:</b>
                                <i>{property.get(item)}</i>
                            </i>
                        );
                      }

                      if (property.type === 'button'){
                        result = (
                            <button className="btn btn-xs" onClick={() => property.onClick(item) }>{property.caption}</button>
                        );
                      }

                      return <div key={j} className="profile-items-prop col-xs-2">{result}</div>
                  }
              );

              return <div className="row profile-items-row" key={i}>{result}</div>
          }
      )

      return <div className="row profile-items-view">
              {template}
          </div>
    }
}

GridView.propTypes = {
  items: PropTypes.array.isRequired,
  properties: PropTypes.array.isRequired
}
