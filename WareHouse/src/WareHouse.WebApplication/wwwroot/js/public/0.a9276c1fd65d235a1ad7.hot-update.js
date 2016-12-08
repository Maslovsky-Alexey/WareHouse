webpackHotUpdate(0,{

/***/ 215:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\n\nvar _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();\n\nvar _react = __webpack_require__(4);\n\nvar _react2 = _interopRequireDefault(_react);\n\nvar _reactRedux = __webpack_require__(26);\n\nvar _redux = __webpack_require__(15);\n\nvar _notifications = __webpack_require__(200);\n\nvar notificationsActions = _interopRequireWildcard(_notifications);\n\nvar _pollingEventManager = __webpack_require__(434);\n\nvar pollingEventManager = _interopRequireWildcard(_pollingEventManager);\n\nfunction _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj.default = obj; return newObj; } }\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return call && (typeof call === \"object\" || typeof call === \"function\") ? call : self; }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function, not \" + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }\n\nvar AppContainer = function (_Component) {\n  _inherits(AppContainer, _Component);\n\n  function AppContainer() {\n    var _ref;\n\n    var _temp, _this, _ret;\n\n    _classCallCheck(this, AppContainer);\n\n    for (var _len = arguments.length, args = Array(_len), _key = 0; _key < _len; _key++) {\n      args[_key] = arguments[_key];\n    }\n\n    return _ret = (_temp = (_this = _possibleConstructorReturn(this, (_ref = AppContainer.__proto__ || Object.getPrototypeOf(AppContainer)).call.apply(_ref, [this].concat(args))), _this), _this.lastTicks = 0, _this.polling = 0, _temp), _possibleConstructorReturn(_this, _ret);\n  }\n\n  _createClass(AppContainer, [{\n    key: 'componentDidMount',\n    value: function componentDidMount() {\n      this.startPoll();\n    }\n  }, {\n    key: 'componentWillUnmount',\n    value: function componentWillUnmount() {\n      clearInterval(this.polling);\n    }\n  }, {\n    key: 'componentWillReceiveProps',\n    value: function componentWillReceiveProps(nextProps) {\n      if (this.props.notifications !== nextProps.notifications) {\n\n        clearInterval(this.polling);\n\n        for (var notification in nextProps.notifications.data) {\n          console.debug(notification.dataType);\n          if (notification.dataType == \"Item\") {\n            console.debug(notification.data);\n            this.props.pollingEventManager.ChangeOrAddItem(notification.data);\n          }\n        }\n\n        if (nextProps.notifications.isFetching === false) {\n          this.startPoll();\n        }\n      }\n    }\n  }, {\n    key: 'startPoll',\n    value: function startPoll() {\n      var getNotifications = this.props.notificationsActions.getNotifications;\n      var lastTicks = this.lastTicks;\n\n      clearInterval(this.polling);\n      this.polling = setInterval(function () {\n        getNotifications(lastTicks);\n      }, 5000);\n    }\n  }, {\n    key: 'render',\n    value: function render() {\n      return _react2.default.createElement(\n        'div',\n        null,\n        this.props.children\n      );\n    }\n  }]);\n\n  return AppContainer;\n}(_react.Component);\n\nfunction mapStateToProps(state) {\n  return {\n    notifications: state.notifications\n  };\n}\n\nfunction mapDispatchToProps(dispatch) {\n  return {\n    notificationsActions: (0, _redux.bindActionCreators)(notificationsActions, dispatch),\n    pollingEventManager: (0, _redux.bindActionCreators)(pollingEventManager, dispatch)\n  };\n}\n\nexports.default = (0, _reactRedux.connect)(mapStateToProps, mapDispatchToProps)(AppContainer);//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMjE1LmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2NvbnRhaW5lcnMvQXBwQ29udGFpbmVyLmpzPzQyMDUiLCJ3ZWJwYWNrOi8vLz9kNDFkIl0sInNvdXJjZXNDb250ZW50IjpbImltcG9ydCBSZWFjdCwgeyBDb21wb25lbnQgfSBmcm9tICdyZWFjdCdcclxuaW1wb3J0IHsgY29ubmVjdCB9IGZyb20gJ3JlYWN0LXJlZHV4J1xyXG5pbXBvcnQgeyBiaW5kQWN0aW9uQ3JlYXRvcnMgfSBmcm9tICdyZWR1eCdcclxuXHJcbmltcG9ydCAqIGFzIG5vdGlmaWNhdGlvbnNBY3Rpb25zIGZyb20gJy4uL2FjdGlvbnMvbm90aWZpY2F0aW9ucy9ub3RpZmljYXRpb25zJ1xyXG5pbXBvcnQgKiBhcyBwb2xsaW5nRXZlbnRNYW5hZ2VyIGZyb20gJy4uL2FjdGlvbnMvcG9sbGluZ0V2ZW50TWFuYWdlci9wb2xsaW5nRXZlbnRNYW5hZ2VyJ1xyXG5cclxuY2xhc3MgQXBwQ29udGFpbmVyIGV4dGVuZHMgQ29tcG9uZW50IHtcclxuICBsYXN0VGlja3MgPSAwXHJcbiAgcG9sbGluZyA9IDBcclxuXHJcbiAgY29tcG9uZW50RGlkTW91bnQoKXtcclxuICAgICAgdGhpcy5zdGFydFBvbGwoKTtcclxuICB9XHJcblxyXG4gIGNvbXBvbmVudFdpbGxVbm1vdW50KCkge1xyXG4gICAgICBjbGVhckludGVydmFsKHRoaXMucG9sbGluZyk7XHJcbiAgfVxyXG5cclxuICBjb21wb25lbnRXaWxsUmVjZWl2ZVByb3BzKG5leHRQcm9wcyl7XHJcbiAgICBpZiAodGhpcy5wcm9wcy5ub3RpZmljYXRpb25zICE9PSBuZXh0UHJvcHMubm90aWZpY2F0aW9ucyl7XHJcblxyXG4gICAgICBjbGVhckludGVydmFsKHRoaXMucG9sbGluZyk7XHJcblxyXG5cclxuXHJcblxyXG4gICAgICBmb3IgKGxldCBub3RpZmljYXRpb24gaW4gbmV4dFByb3BzLm5vdGlmaWNhdGlvbnMuZGF0YSl7XHJcbiAgICAgICAgICBjb25zb2xlLmRlYnVnKG5vdGlmaWNhdGlvbi5kYXRhVHlwZSk7XHJcbiAgICAgICAgaWYgKG5vdGlmaWNhdGlvbi5kYXRhVHlwZSA9PSBcIkl0ZW1cIil7XHJcbiAgICAgICAgICBjb25zb2xlLmRlYnVnKG5vdGlmaWNhdGlvbi5kYXRhKTtcclxuICAgICAgICAgIHRoaXMucHJvcHMucG9sbGluZ0V2ZW50TWFuYWdlci5DaGFuZ2VPckFkZEl0ZW0obm90aWZpY2F0aW9uLmRhdGEpO1xyXG4gICAgICAgIH1cclxuICAgICAgfVxyXG5cclxuXHJcbiAgICAgIGlmIChuZXh0UHJvcHMubm90aWZpY2F0aW9ucy5pc0ZldGNoaW5nID09PSBmYWxzZSl7XHJcbiAgICAgICAgdGhpcy5zdGFydFBvbGwoKTtcclxuICAgICAgfVxyXG4gICAgfVxyXG4gIH1cclxuXHJcbiAgc3RhcnRQb2xsKCl7XHJcbiAgICBsZXQgZ2V0Tm90aWZpY2F0aW9ucyA9IHRoaXMucHJvcHMubm90aWZpY2F0aW9uc0FjdGlvbnMuZ2V0Tm90aWZpY2F0aW9ucztcclxuICAgIGxldCBsYXN0VGlja3MgPSB0aGlzLmxhc3RUaWNrcztcclxuXHJcbiAgICBjbGVhckludGVydmFsKHRoaXMucG9sbGluZyk7XHJcbiAgICB0aGlzLnBvbGxpbmcgPSBzZXRJbnRlcnZhbCgoKSA9PiB7XHJcbiAgICAgIGdldE5vdGlmaWNhdGlvbnMobGFzdFRpY2tzKTtcclxuICAgIH0sIDUwMDApO1xyXG4gIH1cclxuXHJcbiAgcmVuZGVyKCl7XHJcbiAgICByZXR1cm4gPGRpdj57dGhpcy5wcm9wcy5jaGlsZHJlbn08L2Rpdj5cclxuICB9XHJcbn1cclxuXHJcblxyXG5mdW5jdGlvbiBtYXBTdGF0ZVRvUHJvcHMgKHN0YXRlKSB7XHJcbiAgcmV0dXJuIHtcclxuICAgIG5vdGlmaWNhdGlvbnM6IHN0YXRlLm5vdGlmaWNhdGlvbnNcclxuICB9XHJcbn1cclxuXHJcbmZ1bmN0aW9uIG1hcERpc3BhdGNoVG9Qcm9wcyhkaXNwYXRjaCkge1xyXG4gIHJldHVybiB7XHJcbiAgICBub3RpZmljYXRpb25zQWN0aW9uczogYmluZEFjdGlvbkNyZWF0b3JzKG5vdGlmaWNhdGlvbnNBY3Rpb25zLCBkaXNwYXRjaCksXHJcbiAgICBwb2xsaW5nRXZlbnRNYW5hZ2VyOiBiaW5kQWN0aW9uQ3JlYXRvcnMocG9sbGluZ0V2ZW50TWFuYWdlciwgZGlzcGF0Y2gpXHJcbiAgfVxyXG59XHJcblxyXG5leHBvcnQgZGVmYXVsdCBjb25uZWN0KG1hcFN0YXRlVG9Qcm9wcywgbWFwRGlzcGF0Y2hUb1Byb3BzKShBcHBDb250YWluZXIpXHJcblxuXG5cbi8qKiBXRUJQQUNLIEZPT1RFUiAqKlxuICoqIC4vc3JjL2NvbnRhaW5lcnMvQXBwQ29udGFpbmVyLmpzXG4gKiovIiwidW5kZWZpbmVkXG5cblxuLyoqIFdFQlBBQ0sgRk9PVEVSICoqXG4gKiogXG4gKiovIl0sIm1hcHBpbmdzIjoiOzs7Ozs7OztBQUFBO0FBQ0E7OztBQUFBO0FBQ0E7QUFBQTtBQUNBO0FBQ0E7QUFDQTtBQURBO0FBQ0E7QUFBQTtBQUNBO0FBREE7QUFDQTs7Ozs7Ozs7Ozs7QUNDQTs7Ozs7Ozs7Ozs7Ozs7QUFDQTs7Ozs7QUFHQTtBQUNBO0FBQ0E7OztBQUVBO0FBQ0E7QUFDQTs7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUlBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOzs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7OztBQUVBO0FBQ0E7QUFBQTtBQUFBO0FBQUE7QUFBQTtBQUNBOzs7Ozs7QUFJQTtBQUNBO0FBQ0E7QUFEQTtBQUdBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUZBO0FBSUE7QUFDQTsiLCJzb3VyY2VSb290IjoiIn0=");

/***/ }

})