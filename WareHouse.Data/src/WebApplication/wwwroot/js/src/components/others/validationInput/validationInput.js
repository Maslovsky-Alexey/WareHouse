import React, { PropTypes, Component } from 'react'
import '../../../style/components/others/gridView/gridView.css'

export default class ValidationInput extends Component {
    input = {}

    textChange(e){
      let text = $(e.target).val();

      if (this.props.rule.check(text) == true){
        $(this.input).attr("hidden", true);
        this.props.changeValid(true, text);
      } else {
        $(this.input).attr("hidden", false);
        this.props.changeValid(false, text);
      };
    }

    render() {
      return <div>
            <input className="form-control" onChange={::this.textChange} />
            <span hidden ref={(ref) => this.input = $(ref)[0]}>
              <font color="red" size="3">
                {this.props.rule.hint('')}
              </font>
            </span>
          </div>;
    }
}


ValidationInput.propTypes = {
  rule: PropTypes.object.isRequired
};
