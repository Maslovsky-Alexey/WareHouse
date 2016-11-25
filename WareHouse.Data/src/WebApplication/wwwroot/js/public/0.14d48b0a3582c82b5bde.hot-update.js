webpackHotUpdate(0,{

/***/ 322:
/***/ function(module, exports, __webpack_require__) {

	eval("\"use strict\";\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\n\nvar _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();\n\nvar _react = __webpack_require__(4);\n\nvar _react2 = _interopRequireDefault(_react);\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return call && (typeof call === \"object\" || typeof call === \"function\") ? call : self; }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function, not \" + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }\n\nvar List = function (_Component) {\n  _inherits(List, _Component);\n\n  function List() {\n    var _ref;\n\n    var _temp, _this, _ret;\n\n    _classCallCheck(this, List);\n\n    for (var _len = arguments.length, args = Array(_len), _key = 0; _key < _len; _key++) {\n      args[_key] = arguments[_key];\n    }\n\n    return _ret = (_temp = (_this = _possibleConstructorReturn(this, (_ref = List.__proto__ || Object.getPrototypeOf(List)).call.apply(_ref, [this].concat(args))), _this), _this.myTextInput = {}, _temp), _possibleConstructorReturn(_this, _ret);\n  }\n\n  _createClass(List, [{\n    key: \"click\",\n    value: function click(e) {\n      var index = this.myTextInput.selectedIndex;\n      var id = this.myTextInput[index].id;\n\n      this.props.changevalue(id.substring(4));\n    }\n  }, {\n    key: \"render\",\n    value: function render() {\n      var _this2 = this;\n\n      var classname = \"people-list \" + this.props.side + (this.props.active ? \" valid\" : \" invalid\");\n      this.side = this.props.side;\n\n      if (this.props.items.length > 0) this.props.changevalue(this.props.items[0].id);\n      return _react2.default.createElement(\n        \"div\",\n        { className: classname },\n        _react2.default.createElement(\n          \"div\",\n          { className: \"people-list-head\" },\n          _react2.default.createElement(\n            \"div\",\n            { className: \"people-list-title\" },\n            this.props.title\n          ),\n          _react2.default.createElement(\n            \"div\",\n            { className: \"input-group\" },\n            _react2.default.createElement(\n              \"select\",\n              { ref: function ref(_ref2) {\n                  return _this2.myTextInput = $(_ref2)[0];\n                }, onChange: this.click.bind(this) },\n              this.props.items.map(function (item, index) {\n                return _react2.default.createElement(\n                  \"option\",\n                  { active: index == 0, key: index, id: 'opt-' + item.id },\n                  item.name\n                );\n              })\n            )\n          )\n        )\n      );\n    }\n  }]);\n\n  return List;\n}(_react.Component);\n\nexports.default = List;//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMzIyLmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2NvbXBvbmVudHMvb3BlcmF0aW9ucy9saXN0L2xpc3QuanM/NTRhYiIsIndlYnBhY2s6Ly8vP2Q0MWQiXSwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IFJlYWN0LCB7IFByb3BUeXBlcywgQ29tcG9uZW50IH0gZnJvbSAncmVhY3QnXHJcblxyXG5leHBvcnQgZGVmYXVsdCBjbGFzcyBMaXN0IGV4dGVuZHMgQ29tcG9uZW50IHtcclxuICBteVRleHRJbnB1dCA9IHt9XHJcblxyXG4gIGNsaWNrKGUpe1xyXG4gICAgbGV0IGluZGV4ID0gdGhpcy5teVRleHRJbnB1dC5zZWxlY3RlZEluZGV4XHJcbiAgICBsZXQgaWQgPSB0aGlzLm15VGV4dElucHV0W2luZGV4XS5pZFxyXG5cclxuICAgIHRoaXMucHJvcHMuY2hhbmdldmFsdWUoaWQuc3Vic3RyaW5nKDQpKVxyXG4gIH1cclxuXHJcbiAgcmVuZGVyKCkge1xyXG4gICAgbGV0IGNsYXNzbmFtZSA9IFwicGVvcGxlLWxpc3QgXCIgKyB0aGlzLnByb3BzLnNpZGUgKyAodGhpcy5wcm9wcy5hY3RpdmUgPyBcIiB2YWxpZFwiIDogXCIgaW52YWxpZFwiKVxyXG4gICAgdGhpcy5zaWRlID0gdGhpcy5wcm9wcy5zaWRlXHJcblxyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgICBpZiAodGhpcy5wcm9wcy5pdGVtcy5sZW5ndGggPiAwKVxyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgdGhpcy5wcm9wcy5jaGFuZ2V2YWx1ZSh0aGlzLnByb3BzLml0ZW1zWzBdLmlkKVxyXG4gICAgcmV0dXJuIDxkaXYgY2xhc3NOYW1lPXtjbGFzc25hbWV9PlxyXG4gICAgICAgICAgICAgIDxkaXYgY2xhc3NOYW1lPVwicGVvcGxlLWxpc3QtaGVhZFwiPlxyXG4gICAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT1cInBlb3BsZS1saXN0LXRpdGxlXCI+XHJcbiAgICAgICAgICAgICAgICAgICAgICB7dGhpcy5wcm9wcy50aXRsZX1cclxuICAgICAgICAgICAgICAgICAgPC9kaXY+XHJcbiAgICAgICAgICAgICAgICAgIDxkaXYgY2xhc3NOYW1lPVwiaW5wdXQtZ3JvdXBcIj5cclxuICAgICAgICAgICAgICAgICAgICAgIDxzZWxlY3QgcmVmPXsocmVmKSA9PiB0aGlzLm15VGV4dElucHV0ID0gJChyZWYpWzBdfSBvbkNoYW5nZT17Ojp0aGlzLmNsaWNrfT5cclxuICAgICAgICAgICAgICAgICAgICAgICAge1xyXG4gICAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMucHJvcHMuaXRlbXMubWFwKGZ1bmN0aW9uKGl0ZW0sIGluZGV4KXtcclxuICAgICAgICAgICAgICAgICAgICAgICAgICAgIHJldHVybiA8b3B0aW9uIGFjdGl2ZT17aW5kZXggPT0gMH0ga2V5PXtpbmRleH0gaWQ9eydvcHQtJyArIGl0ZW0uaWR9PntpdGVtLm5hbWV9PC9vcHRpb24+XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgfSlcclxuICAgICAgICAgICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAgICAgICAgICAgPC9zZWxlY3Q+XHJcbiAgICAgICAgICAgICAgICAgIDwvZGl2PlxyXG4gICAgICAgICAgICAgIDwvZGl2PlxyXG4gICAgICAgICAgPC9kaXY+XHJcbiAgfVxyXG59XHJcblxuXG5cbi8qKiBXRUJQQUNLIEZPT1RFUiAqKlxuICoqIC4vc3JjL2NvbXBvbmVudHMvb3BlcmF0aW9ucy9saXN0L2xpc3QuanNcbiAqKi8iLCJ1bmRlZmluZWRcblxuXG4vKiogV0VCUEFDSyBGT09URVIgKipcbiAqKiBcbiAqKi8iXSwibWFwcGluZ3MiOiI7Ozs7Ozs7O0FBQUE7QUFDQTs7Ozs7Ozs7Ozs7QUFDQTs7Ozs7Ozs7Ozs7Ozs7QUFDQTs7Ozs7QUNFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7OztBQUVBO0FBQUE7QUFDQTtBQUFBO0FBQ0E7QUFDQTtBQUNBO0FBRUE7QUFBQTtBQUFBO0FBQ0E7QUFBQTtBQUFBO0FBQ0E7QUFBQTtBQUFBO0FBQ0E7QUFEQTtBQUdBO0FBQUE7QUFBQTtBQUNBO0FBQUE7QUFBQTtBQUFBO0FBQUE7QUFFQTtBQUNBO0FBQUE7QUFBQTtBQUFBO0FBQUE7QUFDQTtBQUpBO0FBREE7QUFKQTtBQURBO0FBZ0JBOzs7Ozs7QUFoQ0EiLCJzb3VyY2VSb290IjoiIn0=");

/***/ }

})