webpackHotUpdate(0,{

/***/ 158:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\n\nvar _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();\n\nvar _react = __webpack_require__(4);\n\nvar _react2 = _interopRequireDefault(_react);\n\n__webpack_require__(145);\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return call && (typeof call === \"object\" || typeof call === \"function\") ? call : self; }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function, not \" + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }\n\nvar ValidationInput = function (_Component) {\n  _inherits(ValidationInput, _Component);\n\n  function ValidationInput() {\n    var _ref;\n\n    var _temp, _this, _ret;\n\n    _classCallCheck(this, ValidationInput);\n\n    for (var _len = arguments.length, args = Array(_len), _key = 0; _key < _len; _key++) {\n      args[_key] = arguments[_key];\n    }\n\n    return _ret = (_temp = (_this = _possibleConstructorReturn(this, (_ref = ValidationInput.__proto__ || Object.getPrototypeOf(ValidationInput)).call.apply(_ref, [this].concat(args))), _this), _this.input = {}, _temp), _possibleConstructorReturn(_this, _ret);\n  }\n\n  _createClass(ValidationInput, [{\n    key: 'textChange',\n    value: function textChange(e) {\n      var text = $(e.target).val();\n\n      if (this.props.rule.check(text) == true) {\n        $(this.input).attr(\"hidden\");\n      } else {\n        $(this.input).removeAttr(\"hidden\");\n        console.debug(this.props.rule.hint(text));\n      };\n    }\n  }, {\n    key: 'render',\n    value: function render() {\n      var _this2 = this;\n\n      return _react2.default.createElement(\n        'div',\n        null,\n        _react2.default.createElement('input', { className: 'form-control', onChange: this.textChange.bind(this) }),\n        _react2.default.createElement(\n          'span',\n          { hidden: true, ref: function ref(_ref2) {\n              return _this2.input = $(_ref2)[0];\n            } },\n          _react2.default.createElement(\n            'font',\n            { color: 'red', size: '3' },\n            this.props.rule.hint\n          )\n        )\n      );\n    }\n  }]);\n\n  return ValidationInput;\n}(_react.Component);\n\nexports.default = ValidationInput;\n\n\nValidationInput.propTypes = {\n  rule: _react.PropTypes.object.isRequired\n};//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMTU4LmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2NvbXBvbmVudHMvb3RoZXJzL3ZhbGlkYXRpb25JbnB1dC92YWxpZGF0aW9uSW5wdXQuanM/ZmIxMiIsIndlYnBhY2s6Ly8vP2Q0MWQiXSwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IFJlYWN0LCB7IFByb3BUeXBlcywgQ29tcG9uZW50IH0gZnJvbSAncmVhY3QnXHJcbmltcG9ydCAnLi4vLi4vLi4vc3R5bGUvY29tcG9uZW50cy9vdGhlcnMvZ3JpZFZpZXcvZ3JpZFZpZXcuY3NzJ1xyXG5cclxuZXhwb3J0IGRlZmF1bHQgY2xhc3MgVmFsaWRhdGlvbklucHV0IGV4dGVuZHMgQ29tcG9uZW50IHtcclxuICAgIGlucHV0ID0ge31cclxuXHJcbiAgICB0ZXh0Q2hhbmdlKGUpe1xyXG4gICAgICBsZXQgdGV4dCA9ICQoZS50YXJnZXQpLnZhbCgpO1xyXG5cclxuICAgICAgaWYgKHRoaXMucHJvcHMucnVsZS5jaGVjayh0ZXh0KSA9PSB0cnVlKXtcclxuICAgICAgICAkKHRoaXMuaW5wdXQpLmF0dHIoXCJoaWRkZW5cIik7XHJcblxyXG4gICAgICB9IGVsc2Uge1xyXG4gICAgICAgICQodGhpcy5pbnB1dCkucmVtb3ZlQXR0cihcImhpZGRlblwiKTtcclxuICAgICAgICAgIGNvbnNvbGUuZGVidWcodGhpcy5wcm9wcy5ydWxlLmhpbnQodGV4dCkpO1xyXG4gICAgICB9O1xyXG4gICAgfVxyXG5cclxuICAgIHJlbmRlcigpIHtcclxuICAgICAgcmV0dXJuIDxkaXY+XHJcbiAgICAgICAgICAgIDxpbnB1dCBjbGFzc05hbWU9XCJmb3JtLWNvbnRyb2xcIiBvbkNoYW5nZT17Ojp0aGlzLnRleHRDaGFuZ2V9Lz5cclxuICAgICAgICAgICAgPHNwYW4gaGlkZGVuIHJlZj17KHJlZikgPT4gdGhpcy5pbnB1dCA9ICQocmVmKVswXX0+XHJcbiAgICAgICAgICAgICAgPGZvbnQgY29sb3I9XCJyZWRcIiBzaXplPVwiM1wiPlxyXG4gICAgICAgICAgICAgICAge3RoaXMucHJvcHMucnVsZS5oaW50fTwvZm9udD48L3NwYW4+XHJcbiAgICAgICAgICA8L2Rpdj47XHJcbiAgICB9XHJcbn1cclxuXHJcblxyXG5WYWxpZGF0aW9uSW5wdXQucHJvcFR5cGVzID0ge1xyXG4gIHJ1bGU6IFByb3BUeXBlcy5vYmplY3QuaXNSZXF1aXJlZFxyXG59O1xyXG5cblxuXG4vKiogV0VCUEFDSyBGT09URVIgKipcbiAqKiAuL3NyYy9jb21wb25lbnRzL290aGVycy92YWxpZGF0aW9uSW5wdXQvdmFsaWRhdGlvbklucHV0LmpzXG4gKiovIiwidW5kZWZpbmVkXG5cblxuLyoqIFdFQlBBQ0sgRk9PVEVSICoqXG4gKiogXG4gKiovIl0sIm1hcHBpbmdzIjoiOzs7Ozs7OztBQUFBO0FBQ0E7OztBQUFBO0FBQ0E7Ozs7Ozs7OztBQUNBOzs7Ozs7Ozs7Ozs7OztBQUNBOzs7OztBQ0VBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOzs7QUFFQTtBQUFBO0FBQ0E7QUFBQTtBQUFBO0FBQUE7QUFDQTtBQUNBO0FBQUE7QUFBQTtBQUFBO0FBQUE7QUFDQTtBQUFBO0FBQUE7QUFDQTtBQURBO0FBREE7QUFGQTtBQU1BOzs7Ozs7QUF0QkE7QUFDQTtBQUNBO0FEd0JBO0FDQ0E7QUFEQSIsInNvdXJjZVJvb3QiOiIifQ==");

/***/ }

})