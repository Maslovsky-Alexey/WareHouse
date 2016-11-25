webpackHotUpdate(0,{

/***/ 321:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\n\nvar _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();\n\nvar _react = __webpack_require__(4);\n\nvar _react2 = _interopRequireDefault(_react);\n\nvar _reactRedux = __webpack_require__(36);\n\nvar _redux = __webpack_require__(19);\n\nvar _admin = __webpack_require__(141);\n\nvar adminActions = _interopRequireWildcard(_admin);\n\n__webpack_require__(324);\n\nvar _formOperations = __webpack_require__(325);\n\nvar _formOperations2 = _interopRequireDefault(_formOperations);\n\nfunction _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj.default = obj; return newObj; } }\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return call && (typeof call === \"object\" || typeof call === \"function\") ? call : self; }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function, not \" + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }\n\nvar Operations = function (_Component) {\n  _inherits(Operations, _Component);\n\n  function Operations() {\n    _classCallCheck(this, Operations);\n\n    return _possibleConstructorReturn(this, (Operations.__proto__ || Object.getPrototypeOf(Operations)).apply(this, arguments));\n  }\n\n  _createClass(Operations, [{\n    key: 'componentDidMount',\n    value: function componentDidMount() {\n      this.props.adminActions.getClients();\n      this.props.adminActions.getProviders();\n    }\n  }, {\n    key: 'render',\n    value: function render() {\n      return _react2.default.createElement(\n        'div',\n        { className: 'row' },\n        _react2.default.createElement(_formOperations2.default, { clients: [{ id: 1, name: 'a' }, { id: 2, name: 'b' }], providers: [{ id: 1, name: 'a' }, { id: 2, name: 'b' }], items3: [{ id: 1, name: 'a' }, { id: 2, name: 'b' }] })\n      );\n    }\n  }]);\n\n  return Operations;\n}(_react.Component);\n\nfunction mapStateToProps(state) {\n  return {\n    admin: state.admin\n  };\n}\n\nfunction mapDispatchToProps(dispatch) {\n  return {\n    adminActions: (0, _redux.bindActionCreators)(adminActions, dispatch)\n  };\n}\n\nexports.default = (0, _reactRedux.connect)(mapStateToProps, mapDispatchToProps)(Operations);//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMzIxLmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2NvbnRhaW5lcnMvT3BlcmF0aW9ucy5qcz9kYzViIiwid2VicGFjazovLy8/ZDQxZCJdLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgUmVhY3QsIHsgQ29tcG9uZW50IH0gZnJvbSAncmVhY3QnXHJcbmltcG9ydCB7IGNvbm5lY3QgfSBmcm9tICdyZWFjdC1yZWR1eCdcclxuaW1wb3J0IHsgYmluZEFjdGlvbkNyZWF0b3JzIH0gZnJvbSAncmVkdXgnXHJcblxyXG5pbXBvcnQgKiBhcyBhZG1pbkFjdGlvbnMgZnJvbSAnLi4vYWN0aW9ucy9wcm9maWxlL2FkbWluJ1xyXG5cclxuaW1wb3J0ICcuLi9zdHlsZS9jb21wb25lbnRzL29wZXJhdGlvbnMvb3BlcmF0aW9ucy5jc3MnXHJcblxyXG5pbXBvcnQgRm9ybU9wZXJhdGlvbnMgZnJvbSAnLi4vY29tcG9uZW50cy9vcGVyYXRpb25zL2Zvcm1PcGVyYXRpb25zJ1xyXG5cclxuY2xhc3MgT3BlcmF0aW9ucyBleHRlbmRzIENvbXBvbmVudCB7XHJcbiAgY29tcG9uZW50RGlkTW91bnQoKXtcclxuICAgIHRoaXMucHJvcHMuYWRtaW5BY3Rpb25zLmdldENsaWVudHMoKVxyXG4gICAgdGhpcy5wcm9wcy5hZG1pbkFjdGlvbnMuZ2V0UHJvdmlkZXJzKClcclxuICB9XHJcblxyXG4gIHJlbmRlcigpe1xyXG4gICAgcmV0dXJuIDxkaXYgY2xhc3NOYW1lPVwicm93XCI+XHJcbiAgICAgICAgICA8Rm9ybU9wZXJhdGlvbnMgY2xpZW50cz17W3tpZDogMSwgbmFtZTogJ2EnfSwge2lkOiAyLCBuYW1lOiAnYid9XX0gcHJvdmlkZXJzPXtbe2lkOiAxLCBuYW1lOiAnYSd9LCB7aWQ6IDIsIG5hbWU6ICdiJ31dfSBpdGVtczM9e1t7aWQ6IDEsIG5hbWU6ICdhJ30sIHtpZDogMiwgbmFtZTogJ2InfV19IC8+XHJcbiAgICAgPC9kaXY+XHJcbiAgfVxyXG59XHJcblxyXG5cclxuZnVuY3Rpb24gbWFwU3RhdGVUb1Byb3BzIChzdGF0ZSkge1xyXG4gIHJldHVybiB7XHJcbiAgICBhZG1pbjogc3RhdGUuYWRtaW5cclxuICB9XHJcbn1cclxuXHJcbmZ1bmN0aW9uIG1hcERpc3BhdGNoVG9Qcm9wcyhkaXNwYXRjaCkge1xyXG4gIHJldHVybiB7XHJcbiAgICBhZG1pbkFjdGlvbnM6IGJpbmRBY3Rpb25DcmVhdG9ycyhhZG1pbkFjdGlvbnMsIGRpc3BhdGNoKVxyXG4gIH1cclxufVxyXG5cclxuZXhwb3J0IGRlZmF1bHQgY29ubmVjdChtYXBTdGF0ZVRvUHJvcHMsIG1hcERpc3BhdGNoVG9Qcm9wcykoT3BlcmF0aW9ucylcclxuXG5cblxuLyoqIFdFQlBBQ0sgRk9PVEVSICoqXG4gKiogLi9zcmMvY29udGFpbmVycy9PcGVyYXRpb25zLmpzXG4gKiovIiwidW5kZWZpbmVkXG5cblxuLyoqIFdFQlBBQ0sgRk9PVEVSICoqXG4gKiogXG4gKiovIl0sIm1hcHBpbmdzIjoiOzs7Ozs7OztBQUFBO0FBQ0E7OztBQUFBO0FBQ0E7QUFBQTtBQUNBO0FBQ0E7QUFDQTtBQURBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7Ozs7Ozs7Ozs7OztBQUNBOzs7Ozs7Ozs7OztBQ0NBO0FBQ0E7QUFDQTtBQUNBOzs7QUFFQTtBQUNBO0FBQUE7QUFBQTtBQUNBO0FBREE7QUFHQTs7Ozs7O0FBSUE7QUFDQTtBQUNBO0FBREE7QUFHQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBREE7QUFHQTtBQUNBOyIsInNvdXJjZVJvb3QiOiIifQ==");

/***/ }

})