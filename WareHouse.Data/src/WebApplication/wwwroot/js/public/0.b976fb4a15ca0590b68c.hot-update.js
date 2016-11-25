webpackHotUpdate(0,{

/***/ 321:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\n\nvar _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();\n\nvar _react = __webpack_require__(4);\n\nvar _react2 = _interopRequireDefault(_react);\n\nvar _reactRedux = __webpack_require__(36);\n\nvar _redux = __webpack_require__(19);\n\nvar _admin = __webpack_require__(141);\n\nvar adminActions = _interopRequireWildcard(_admin);\n\nvar _orders = __webpack_require__(140);\n\nvar orderActions = _interopRequireWildcard(_orders);\n\nvar _supplies = __webpack_require__(142);\n\nvar supplyActions = _interopRequireWildcard(_supplies);\n\nvar _items = __webpack_require__(327);\n\nvar itemsActions = _interopRequireWildcard(_items);\n\n__webpack_require__(324);\n\nvar _formOperations = __webpack_require__(325);\n\nvar _formOperations2 = _interopRequireDefault(_formOperations);\n\nfunction _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj.default = obj; return newObj; } }\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return call && (typeof call === \"object\" || typeof call === \"function\") ? call : self; }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function, not \" + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }\n\nvar Operations = function (_Component) {\n  _inherits(Operations, _Component);\n\n  function Operations() {\n    _classCallCheck(this, Operations);\n\n    return _possibleConstructorReturn(this, (Operations.__proto__ || Object.getPrototypeOf(Operations)).apply(this, arguments));\n  }\n\n  _createClass(Operations, [{\n    key: 'componentDidMount',\n    value: function componentDidMount() {\n      this.props.adminActions.getClients();\n      this.props.adminActions.getProviders();\n    }\n  }, {\n    key: 'addItem',\n    value: function addItem(provider, client, item, count, isSupply) {\n      if (isSupply) {\n        this.props.supplyActions.addSupply(item, count, provider, this.props.about.id);\n      } else {\n        this.props.orderActions.addOrder(item, count, client, this.props.about.id);\n      }\n    }\n  }, {\n    key: 'render',\n    value: function render() {\n      return _react2.default.createElement(\n        'div',\n        { className: 'row' },\n        _react2.default.createElement(_formOperations2.default, { clients: this.props.admin.clients, providers: this.props.admin.providers, items: [{ id: 1, name: 'a' }, { id: 2, name: 'b' }], send: this.addItem.bind(this) })\n      );\n    }\n  }]);\n\n  return Operations;\n}(_react.Component);\n\nfunction mapStateToProps(state) {\n  return {\n    admin: state.admin,\n    order: state.order,\n    supply: state.supply,\n    about: state.about,\n    items: state.items\n  };\n}\n\nfunction mapDispatchToProps(dispatch) {\n  return {\n    adminActions: (0, _redux.bindActionCreators)(adminActions, dispatch),\n    supplyActions: (0, _redux.bindActionCreators)(supplyActions, dispatch),\n    orderActions: (0, _redux.bindActionCreators)(orderActions, dispatch),\n    itemsActions: (0, _redux.bindActionCreators)(orderActions, dispatch)\n  };\n}\n\nexports.default = (0, _reactRedux.connect)(mapStateToProps, mapDispatchToProps)(Operations);//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMzIxLmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2NvbnRhaW5lcnMvT3BlcmF0aW9ucy5qcz9kYzViIiwid2VicGFjazovLy8/ZDQxZCJdLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgUmVhY3QsIHsgQ29tcG9uZW50IH0gZnJvbSAncmVhY3QnXHJcbmltcG9ydCB7IGNvbm5lY3QgfSBmcm9tICdyZWFjdC1yZWR1eCdcclxuaW1wb3J0IHsgYmluZEFjdGlvbkNyZWF0b3JzIH0gZnJvbSAncmVkdXgnXHJcblxyXG5pbXBvcnQgKiBhcyBhZG1pbkFjdGlvbnMgZnJvbSAnLi4vYWN0aW9ucy9wcm9maWxlL2FkbWluJ1xyXG5pbXBvcnQgKiBhcyBvcmRlckFjdGlvbnMgZnJvbSAnLi4vYWN0aW9ucy9vcmRlcnMvb3JkZXJzJ1xyXG5pbXBvcnQgKiBhcyBzdXBwbHlBY3Rpb25zIGZyb20gJy4uL2FjdGlvbnMvc3VwcGxpZXMvc3VwcGxpZXMnXHJcbmltcG9ydCAqIGFzIGl0ZW1zQWN0aW9ucyBmcm9tICcuLi9hY3Rpb25zL2l0ZW1zL2l0ZW1zJ1xyXG5cclxuaW1wb3J0ICcuLi9zdHlsZS9jb21wb25lbnRzL29wZXJhdGlvbnMvb3BlcmF0aW9ucy5jc3MnXHJcblxyXG5pbXBvcnQgRm9ybU9wZXJhdGlvbnMgZnJvbSAnLi4vY29tcG9uZW50cy9vcGVyYXRpb25zL2Zvcm1PcGVyYXRpb25zJ1xyXG5cclxuY2xhc3MgT3BlcmF0aW9ucyBleHRlbmRzIENvbXBvbmVudCB7XHJcbiAgY29tcG9uZW50RGlkTW91bnQoKXtcclxuICAgIHRoaXMucHJvcHMuYWRtaW5BY3Rpb25zLmdldENsaWVudHMoKVxyXG4gICAgdGhpcy5wcm9wcy5hZG1pbkFjdGlvbnMuZ2V0UHJvdmlkZXJzKClcclxuICB9XHJcblxyXG4gIGFkZEl0ZW0ocHJvdmlkZXIsIGNsaWVudCwgaXRlbSwgY291bnQsIGlzU3VwcGx5KXtcclxuICAgIGlmIChpc1N1cHBseSl7XHJcbiAgICAgIHRoaXMucHJvcHMuc3VwcGx5QWN0aW9ucy5hZGRTdXBwbHkoaXRlbSwgY291bnQsIHByb3ZpZGVyLCB0aGlzLnByb3BzLmFib3V0LmlkKVxyXG4gICAgfVxyXG4gICAgZWxzZXtcclxuICAgICAgdGhpcy5wcm9wcy5vcmRlckFjdGlvbnMuYWRkT3JkZXIoaXRlbSwgY291bnQsIGNsaWVudCwgdGhpcy5wcm9wcy5hYm91dC5pZClcclxuICAgIH1cclxuICB9XHJcblxyXG4gIHJlbmRlcigpe1xyXG4gICAgcmV0dXJuIDxkaXYgY2xhc3NOYW1lPVwicm93XCI+XHJcbiAgICAgICAgICA8Rm9ybU9wZXJhdGlvbnMgY2xpZW50cz17dGhpcy5wcm9wcy5hZG1pbi5jbGllbnRzfSBwcm92aWRlcnM9e3RoaXMucHJvcHMuYWRtaW4ucHJvdmlkZXJzfSBpdGVtcz17W3tpZDogMSwgbmFtZTogJ2EnfSwge2lkOiAyLCBuYW1lOiAnYid9XX0gc2VuZD17Ojp0aGlzLmFkZEl0ZW19Lz5cclxuICAgICA8L2Rpdj5cclxuICB9XHJcbn1cclxuXHJcblxyXG5mdW5jdGlvbiBtYXBTdGF0ZVRvUHJvcHMgKHN0YXRlKSB7XHJcbiAgcmV0dXJuIHtcclxuICAgIGFkbWluOiBzdGF0ZS5hZG1pbixcclxuICAgIG9yZGVyOiBzdGF0ZS5vcmRlcixcclxuICAgIHN1cHBseTogc3RhdGUuc3VwcGx5LFxyXG4gICAgYWJvdXQ6IHN0YXRlLmFib3V0LFxyXG4gICAgaXRlbXM6IHN0YXRlLml0ZW1zXHJcbiAgfVxyXG59XHJcblxyXG5mdW5jdGlvbiBtYXBEaXNwYXRjaFRvUHJvcHMoZGlzcGF0Y2gpIHtcclxuICByZXR1cm4ge1xyXG4gICAgYWRtaW5BY3Rpb25zOiBiaW5kQWN0aW9uQ3JlYXRvcnMoYWRtaW5BY3Rpb25zLCBkaXNwYXRjaCksXHJcbiAgICBzdXBwbHlBY3Rpb25zOiBiaW5kQWN0aW9uQ3JlYXRvcnMoc3VwcGx5QWN0aW9ucywgZGlzcGF0Y2gpLFxyXG4gICAgb3JkZXJBY3Rpb25zOiBiaW5kQWN0aW9uQ3JlYXRvcnMob3JkZXJBY3Rpb25zLCBkaXNwYXRjaCksXHJcbiAgICBpdGVtc0FjdGlvbnM6IGJpbmRBY3Rpb25DcmVhdG9ycyhvcmRlckFjdGlvbnMsIGRpc3BhdGNoKSxcclxuICB9XHJcbn1cclxuXHJcbmV4cG9ydCBkZWZhdWx0IGNvbm5lY3QobWFwU3RhdGVUb1Byb3BzLCBtYXBEaXNwYXRjaFRvUHJvcHMpKE9wZXJhdGlvbnMpXHJcblxuXG5cbi8qKiBXRUJQQUNLIEZPT1RFUiAqKlxuICoqIC4vc3JjL2NvbnRhaW5lcnMvT3BlcmF0aW9ucy5qc1xuICoqLyIsInVuZGVmaW5lZFxuXG5cbi8qKiBXRUJQQUNLIEZPT1RFUiAqKlxuICoqIFxuICoqLyJdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7QUFBQTtBQUNBOzs7QUFBQTtBQUNBO0FBQUE7QUFDQTtBQUNBO0FBQ0E7QUFEQTtBQUNBO0FBQUE7QUFDQTtBQURBO0FBQ0E7QUNBQTtBQUNBO0FBREE7QUFDQTtBQUFBO0FBQ0E7QUFEQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7Ozs7Ozs7Ozs7Ozs7QUFDQTs7Ozs7Ozs7Ozs7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFFQTtBQUNBO0FBQ0E7OztBQUVBO0FBQ0E7QUFBQTtBQUFBO0FBQ0E7QUFEQTtBQUdBOzs7Ozs7QUFJQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUxBO0FBT0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUpBO0FBTUE7QUFDQTsiLCJzb3VyY2VSb290IjoiIn0=");

/***/ }

})