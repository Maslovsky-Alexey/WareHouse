webpackHotUpdate(0,{

/***/ 154:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\n\nvar _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();\n\nvar _react = __webpack_require__(4);\n\nvar _react2 = _interopRequireDefault(_react);\n\nvar _reactRedux = __webpack_require__(36);\n\nvar _redux = __webpack_require__(19);\n\nvar _items = __webpack_require__(319);\n\nvar itemActions = _interopRequireWildcard(_items);\n\nvar _addItemForm = __webpack_require__(318);\n\nvar _addItemForm2 = _interopRequireDefault(_addItemForm);\n\nfunction _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj.default = obj; return newObj; } }\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return call && (typeof call === \"object\" || typeof call === \"function\") ? call : self; }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function, not \" + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }\n\nvar AddItem = function (_Component) {\n  _inherits(AddItem, _Component);\n\n  function AddItem() {\n    _classCallCheck(this, AddItem);\n\n    return _possibleConstructorReturn(this, (AddItem.__proto__ || Object.getPrototypeOf(AddItem)).apply(this, arguments));\n  }\n\n  _createClass(AddItem, [{\n    key: 'componentDidMount',\n    value: function componentDidMount() {}\n  }, {\n    key: 'render',\n    value: function render() {\n      var addItem = this.props.itemActions.addItem;\n\n      return _react2.default.createElement(_addItemForm2.default, { send: function send(value) {\n          return console.debug(value);\n        } });\n    }\n  }]);\n\n  return AddItem;\n}(_react.Component);\n\nfunction mapStateToProps(state) {\n  return {};\n}\n\nfunction mapDispatchToProps(dispatch) {\n  return {\n    itemActions: (0, _redux.bindActionCreators)(itemActions, dispatch)\n  };\n}\n\nexports.default = (0, _reactRedux.connect)(mapStateToProps, mapDispatchToProps)(AddItem);//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMTU0LmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2NvbnRhaW5lcnMvQWRkSXRlbS5qcz83NTUyIiwid2VicGFjazovLy8/ZDQxZCJdLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgUmVhY3QsIHsgQ29tcG9uZW50IH0gZnJvbSAncmVhY3QnXHJcbmltcG9ydCB7IGNvbm5lY3QgfSBmcm9tICdyZWFjdC1yZWR1eCdcclxuaW1wb3J0IHsgYmluZEFjdGlvbkNyZWF0b3JzIH0gZnJvbSAncmVkdXgnXHJcblxyXG5pbXBvcnQgKiBhcyBpdGVtQWN0aW9ucyBmcm9tICcuLi9hY3Rpb25zL2FkZGl0ZW0vaXRlbXMnXHJcblxyXG5pbXBvcnQgQWRkSXRlbUZvcm0gZnJvbSAnLi4vY29tcG9uZW50cy9hZGRJdGVtL2FkZEl0ZW1Gb3JtJ1xyXG5cclxuY2xhc3MgQWRkSXRlbSBleHRlbmRzIENvbXBvbmVudCB7XHJcbiAgY29tcG9uZW50RGlkTW91bnQoKXtcclxuXHJcbiAgfVxyXG5cclxuICByZW5kZXIoKXtcclxuICAgIGNvbnN0IHthZGRJdGVtfSA9IHRoaXMucHJvcHMuaXRlbUFjdGlvbnNcclxuICAgIHJldHVybiA8QWRkSXRlbUZvcm0gc2VuZD17KHZhbHVlKSA9PiBjb25zb2xlLmRlYnVnKHZhbHVlKX0vPlxyXG4gIH1cclxufVxyXG5cclxuXHJcblxyXG5mdW5jdGlvbiBtYXBTdGF0ZVRvUHJvcHMgKHN0YXRlKSB7XHJcbiAgcmV0dXJuIHtcclxuICB9XHJcbn1cclxuXHJcbmZ1bmN0aW9uIG1hcERpc3BhdGNoVG9Qcm9wcyhkaXNwYXRjaCkge1xyXG4gIHJldHVybiB7XHJcbiAgICBpdGVtQWN0aW9uczogYmluZEFjdGlvbkNyZWF0b3JzKGl0ZW1BY3Rpb25zLCBkaXNwYXRjaClcclxuICB9XHJcbn1cclxuXHJcbmV4cG9ydCBkZWZhdWx0IGNvbm5lY3QobWFwU3RhdGVUb1Byb3BzLCBtYXBEaXNwYXRjaFRvUHJvcHMpKEFkZEl0ZW0pXHJcblxuXG5cbi8qKiBXRUJQQUNLIEZPT1RFUiAqKlxuICoqIC4vc3JjL2NvbnRhaW5lcnMvQWRkSXRlbS5qc1xuICoqLyIsInVuZGVmaW5lZFxuXG5cbi8qKiBXRUJQQUNLIEZPT1RFUiAqKlxuICoqIFxuICoqLyJdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7QUFBQTtBQUNBOzs7QUFBQTtBQUNBO0FBQUE7QUFDQTtBQUNBO0FBQ0E7QUFEQTtBQUNBO0FBQ0E7QUFDQTs7Ozs7Ozs7Ozs7OztBQUNBOzs7Ozs7Ozs7OztBQ0NBOzs7QUFJQTtBQUFBO0FBQ0E7QUFDQTtBQUFBO0FBQUE7QUFDQTs7Ozs7O0FBS0E7QUFDQTtBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFEQTtBQUdBO0FBQ0E7Iiwic291cmNlUm9vdCI6IiJ9");

/***/ }

})