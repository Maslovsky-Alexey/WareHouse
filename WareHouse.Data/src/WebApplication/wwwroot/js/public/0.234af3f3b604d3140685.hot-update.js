webpackHotUpdate(0,{

/***/ 322:
/***/ function(module, exports, __webpack_require__) {

	eval("\"use strict\";\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\n\nvar _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();\n\nvar _react = __webpack_require__(4);\n\nvar _react2 = _interopRequireDefault(_react);\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return call && (typeof call === \"object\" || typeof call === \"function\") ? call : self; }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function, not \" + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }\n\nvar List = function (_Component) {\n  _inherits(List, _Component);\n\n  function List() {\n    var _ref;\n\n    var _temp, _this, _ret;\n\n    _classCallCheck(this, List);\n\n    for (var _len = arguments.length, args = Array(_len), _key = 0; _key < _len; _key++) {\n      args[_key] = arguments[_key];\n    }\n\n    return _ret = (_temp = (_this = _possibleConstructorReturn(this, (_ref = List.__proto__ || Object.getPrototypeOf(List)).call.apply(_ref, [this].concat(args))), _this), _this.myTextInput = {}, _temp), _possibleConstructorReturn(_this, _ret);\n  }\n\n  _createClass(List, [{\n    key: \"click\",\n    value: function click(e) {\n      console.debug($(e.target));\n      this.props.changevalue(e[e.selectedIndex].id.sub(4));\n    }\n  }, {\n    key: \"render\",\n    value: function render() {\n      var _this2 = this;\n\n      var classname = \"people-list \" + this.props.side + (this.props.active ? \" valid\" : \" invalid\");\n      this.side = this.props.side;\n\n      return _react2.default.createElement(\n        \"div\",\n        { className: classname },\n        _react2.default.createElement(\n          \"div\",\n          { className: \"people-list-head\" },\n          _react2.default.createElement(\n            \"div\",\n            { className: \"people-list-title\" },\n            this.props.title\n          ),\n          _react2.default.createElement(\n            \"div\",\n            { className: \"input-group\" },\n            _react2.default.createElement(\n              \"select\",\n              { ref: function ref(_ref2) {\n                  return _this2.myTextInput = $(_ref2);\n                }, onChange: this.click },\n              this.props.items.map(function (item, index) {\n                return _react2.default.createElement(\n                  \"option\",\n                  { active: index == 0, id: 'opt-' + item.id },\n                  item.name\n                );\n              })\n            )\n          )\n        )\n      );\n    }\n  }]);\n\n  return List;\n}(_react.Component);\n\nexports.default = List;//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMzIyLmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2NvbXBvbmVudHMvb3BlcmF0aW9ucy9saXN0L2xpc3QuanM/NTRhYiIsIndlYnBhY2s6Ly8vP2Q0MWQiXSwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IFJlYWN0LCB7IFByb3BUeXBlcywgQ29tcG9uZW50IH0gZnJvbSAncmVhY3QnXHJcblxyXG5leHBvcnQgZGVmYXVsdCBjbGFzcyBMaXN0IGV4dGVuZHMgQ29tcG9uZW50IHtcclxuICBteVRleHRJbnB1dCA9IHt9XHJcblxyXG4gIGNsaWNrKGUpe1xyXG4gICAgY29uc29sZS5kZWJ1ZygkKGUudGFyZ2V0KSlcclxuICAgIHRoaXMucHJvcHMuY2hhbmdldmFsdWUoZVtlLnNlbGVjdGVkSW5kZXhdLmlkLnN1Yig0KSlcclxuICB9XHJcblxyXG4gIHJlbmRlcigpIHtcclxuICAgIGxldCBjbGFzc25hbWUgPSBcInBlb3BsZS1saXN0IFwiICsgdGhpcy5wcm9wcy5zaWRlICsgKHRoaXMucHJvcHMuYWN0aXZlID8gXCIgdmFsaWRcIiA6IFwiIGludmFsaWRcIilcclxuICAgIHRoaXMuc2lkZSA9IHRoaXMucHJvcHMuc2lkZVxyXG5cclxuICAgIHJldHVybiA8ZGl2IGNsYXNzTmFtZT17Y2xhc3NuYW1lfT5cclxuICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT1cInBlb3BsZS1saXN0LWhlYWRcIj5cclxuICAgICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9XCJwZW9wbGUtbGlzdC10aXRsZVwiPlxyXG4gICAgICAgICAgICAgICAgICAgICAge3RoaXMucHJvcHMudGl0bGV9XHJcbiAgICAgICAgICAgICAgICAgIDwvZGl2PlxyXG4gICAgICAgICAgICAgICAgICA8ZGl2IGNsYXNzTmFtZT1cImlucHV0LWdyb3VwXCI+XHJcbiAgICAgICAgICAgICAgICAgICAgICA8c2VsZWN0IHJlZj17KHJlZikgPT4gdGhpcy5teVRleHRJbnB1dCA9ICQocmVmKX0gb25DaGFuZ2U9e3RoaXMuY2xpY2t9PlxyXG4gICAgICAgICAgICAgICAgICAgICAgICB7XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgdGhpcy5wcm9wcy5pdGVtcy5tYXAoZnVuY3Rpb24oaXRlbSwgaW5kZXgpe1xyXG4gICAgICAgICAgICAgICAgICAgICAgICAgICAgcmV0dXJuIDxvcHRpb24gYWN0aXZlPXtpbmRleCA9PSAwfSBpZD17J29wdC0nICsgaXRlbS5pZH0+e2l0ZW0ubmFtZX08L29wdGlvbj5cclxuICAgICAgICAgICAgICAgICAgICAgICAgICB9KVxyXG4gICAgICAgICAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICAgICAgICA8L3NlbGVjdD5cclxuICAgICAgICAgICAgICAgICAgPC9kaXY+XHJcbiAgICAgICAgICAgICAgPC9kaXY+XHJcbiAgICAgICAgICA8L2Rpdj5cclxuICB9XHJcbn1cclxuXG5cblxuLyoqIFdFQlBBQ0sgRk9PVEVSICoqXG4gKiogLi9zcmMvY29tcG9uZW50cy9vcGVyYXRpb25zL2xpc3QvbGlzdC5qc1xuICoqLyIsInVuZGVmaW5lZFxuXG5cbi8qKiBXRUJQQUNLIEZPT1RFUiAqKlxuICoqIFxuICoqLyJdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7QUFBQTtBQUNBOzs7Ozs7Ozs7OztBQUNBOzs7Ozs7Ozs7Ozs7OztBQUNBOzs7OztBQ0VBO0FBQ0E7QUFDQTtBQUNBOzs7QUFFQTtBQUFBO0FBQ0E7QUFBQTtBQUNBO0FBQ0E7QUFDQTtBQUFBO0FBQUE7QUFDQTtBQUFBO0FBQUE7QUFDQTtBQUFBO0FBQUE7QUFDQTtBQURBO0FBR0E7QUFBQTtBQUFBO0FBQ0E7QUFBQTtBQUFBO0FBQUE7QUFBQTtBQUVBO0FBQ0E7QUFBQTtBQUFBO0FBQUE7QUFBQTtBQUNBO0FBSkE7QUFEQTtBQUpBO0FBREE7QUFnQkE7Ozs7OztBQTVCQSIsInNvdXJjZVJvb3QiOiIifQ==");

/***/ }

})