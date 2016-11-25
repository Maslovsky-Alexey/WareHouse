webpackHotUpdate(0,{

/***/ 321:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\n\nvar _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();\n\nvar _react = __webpack_require__(4);\n\nvar _react2 = _interopRequireDefault(_react);\n\nvar _reactRedux = __webpack_require__(36);\n\nvar _redux = __webpack_require__(19);\n\nvar _admin = __webpack_require__(141);\n\nvar adminActions = _interopRequireWildcard(_admin);\n\n__webpack_require__(324);\n\nvar _formOperations = __webpack_require__(325);\n\nvar _formOperations2 = _interopRequireDefault(_formOperations);\n\nfunction _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj.default = obj; return newObj; } }\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return call && (typeof call === \"object\" || typeof call === \"function\") ? call : self; }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function, not \" + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }\n\nvar Operations = function (_Component) {\n  _inherits(Operations, _Component);\n\n  function Operations() {\n    _classCallCheck(this, Operations);\n\n    return _possibleConstructorReturn(this, (Operations.__proto__ || Object.getPrototypeOf(Operations)).apply(this, arguments));\n  }\n\n  _createClass(Operations, [{\n    key: 'componentDidMount',\n    value: function componentDidMount() {\n      this.props.adminActions.getClients();\n      this.props.adminActions.getProviders();\n    }\n  }, {\n    key: 'render',\n    value: function render() {\n      return _react2.default.createElement(\n        'div',\n        { className: 'row' },\n        _react2.default.createElement(_formOperations2.default, { clients: this.props.admin.clients, providers: [{ id: 1, name: 'a' }, { id: 2, name: 'b' }], items: [{ id: 1, name: 'a' }, { id: 2, name: 'b' }] })\n      );\n    }\n  }]);\n\n  return Operations;\n}(_react.Component);\n\nfunction mapStateToProps(state) {\n  return {\n    admin: state.admin\n  };\n}\n\nfunction mapDispatchToProps(dispatch) {\n  return {\n    adminActions: (0, _redux.bindActionCreators)(adminActions, dispatch)\n  };\n}\n\nexports.default = (0, _reactRedux.connect)(mapStateToProps, mapDispatchToProps)(Operations);//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMzIxLmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2NvbnRhaW5lcnMvT3BlcmF0aW9ucy5qcz9kYzViIiwid2VicGFjazovLy8/ZDQxZCJdLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgUmVhY3QsIHsgQ29tcG9uZW50IH0gZnJvbSAncmVhY3QnXHJcbmltcG9ydCB7IGNvbm5lY3QgfSBmcm9tICdyZWFjdC1yZWR1eCdcclxuaW1wb3J0IHsgYmluZEFjdGlvbkNyZWF0b3JzIH0gZnJvbSAncmVkdXgnXHJcblxyXG5pbXBvcnQgKiBhcyBhZG1pbkFjdGlvbnMgZnJvbSAnLi4vYWN0aW9ucy9wcm9maWxlL2FkbWluJ1xyXG5cclxuaW1wb3J0ICcuLi9zdHlsZS9jb21wb25lbnRzL29wZXJhdGlvbnMvb3BlcmF0aW9ucy5jc3MnXHJcblxyXG5pbXBvcnQgRm9ybU9wZXJhdGlvbnMgZnJvbSAnLi4vY29tcG9uZW50cy9vcGVyYXRpb25zL2Zvcm1PcGVyYXRpb25zJ1xyXG5cclxuY2xhc3MgT3BlcmF0aW9ucyBleHRlbmRzIENvbXBvbmVudCB7XHJcbiAgY29tcG9uZW50RGlkTW91bnQoKXtcclxuICAgIHRoaXMucHJvcHMuYWRtaW5BY3Rpb25zLmdldENsaWVudHMoKVxyXG4gICAgdGhpcy5wcm9wcy5hZG1pbkFjdGlvbnMuZ2V0UHJvdmlkZXJzKClcclxuICB9XHJcblxyXG4gIHJlbmRlcigpe1xyXG4gICAgcmV0dXJuIDxkaXYgY2xhc3NOYW1lPVwicm93XCI+XHJcbiAgICAgICAgICA8Rm9ybU9wZXJhdGlvbnMgY2xpZW50cz17dGhpcy5wcm9wcy5hZG1pbi5jbGllbnRzfSBwcm92aWRlcnM9e1t7aWQ6IDEsIG5hbWU6ICdhJ30sIHtpZDogMiwgbmFtZTogJ2InfV19IGl0ZW1zPXtbe2lkOiAxLCBuYW1lOiAnYSd9LCB7aWQ6IDIsIG5hbWU6ICdiJ31dfSAvPlxyXG4gICAgIDwvZGl2PlxyXG4gIH1cclxufVxyXG5cclxuXHJcbmZ1bmN0aW9uIG1hcFN0YXRlVG9Qcm9wcyAoc3RhdGUpIHtcclxuICByZXR1cm4ge1xyXG4gICAgYWRtaW46IHN0YXRlLmFkbWluXHJcbiAgfVxyXG59XHJcblxyXG5mdW5jdGlvbiBtYXBEaXNwYXRjaFRvUHJvcHMoZGlzcGF0Y2gpIHtcclxuICByZXR1cm4ge1xyXG4gICAgYWRtaW5BY3Rpb25zOiBiaW5kQWN0aW9uQ3JlYXRvcnMoYWRtaW5BY3Rpb25zLCBkaXNwYXRjaClcclxuICB9XHJcbn1cclxuXHJcbmV4cG9ydCBkZWZhdWx0IGNvbm5lY3QobWFwU3RhdGVUb1Byb3BzLCBtYXBEaXNwYXRjaFRvUHJvcHMpKE9wZXJhdGlvbnMpXHJcblxuXG5cbi8qKiBXRUJQQUNLIEZPT1RFUiAqKlxuICoqIC4vc3JjL2NvbnRhaW5lcnMvT3BlcmF0aW9ucy5qc1xuICoqLyIsInVuZGVmaW5lZFxuXG5cbi8qKiBXRUJQQUNLIEZPT1RFUiAqKlxuICoqIFxuICoqLyJdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7QUFBQTtBQUNBOzs7QUFBQTtBQUNBO0FBQUE7QUFDQTtBQUNBO0FBQ0E7QUFEQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7Ozs7Ozs7Ozs7Ozs7QUFDQTs7Ozs7Ozs7Ozs7QUNDQTtBQUNBO0FBQ0E7QUFDQTs7O0FBRUE7QUFDQTtBQUFBO0FBQUE7QUFDQTtBQURBO0FBR0E7Ozs7OztBQUlBO0FBQ0E7QUFDQTtBQURBO0FBR0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQURBO0FBR0E7QUFDQTsiLCJzb3VyY2VSb290IjoiIn0=");

/***/ }

})