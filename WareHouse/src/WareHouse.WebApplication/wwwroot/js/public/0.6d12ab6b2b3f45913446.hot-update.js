webpackHotUpdate(0,{

/***/ 215:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\n\nvar _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();\n\nvar _react = __webpack_require__(4);\n\nvar _react2 = _interopRequireDefault(_react);\n\nvar _reactRedux = __webpack_require__(26);\n\nvar _redux = __webpack_require__(15);\n\nvar _notifications = __webpack_require__(200);\n\nvar notificationsActions = _interopRequireWildcard(_notifications);\n\nvar _pollingEventManager = __webpack_require__(434);\n\nvar pollingEventManager = _interopRequireWildcard(_pollingEventManager);\n\nfunction _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj.default = obj; return newObj; } }\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return call && (typeof call === \"object\" || typeof call === \"function\") ? call : self; }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function, not \" + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }\n\nvar AppContainer = function (_Component) {\n  _inherits(AppContainer, _Component);\n\n  function AppContainer() {\n    var _ref;\n\n    var _temp, _this, _ret;\n\n    _classCallCheck(this, AppContainer);\n\n    for (var _len = arguments.length, args = Array(_len), _key = 0; _key < _len; _key++) {\n      args[_key] = arguments[_key];\n    }\n\n    return _ret = (_temp = (_this = _possibleConstructorReturn(this, (_ref = AppContainer.__proto__ || Object.getPrototypeOf(AppContainer)).call.apply(_ref, [this].concat(args))), _this), _this.lastTicks = 0, _this.polling = 0, _this.eventSender = [], _temp), _possibleConstructorReturn(_this, _ret);\n  }\n\n  _createClass(AppContainer, [{\n    key: 'componentDidMount',\n    value: function componentDidMount() {\n      this.eventSender.push({ dataType: \"Item\", action: this.props.pollingEventManager.ChangeOrAddItem });\n      this.eventSender.push({ dataType: \"Supply\", action: this.props.pollingEventManager.ChangeOrAddSupply });\n      this.eventSender.push({ dataType: \"Order\", action: this.props.pollingEventManager.ChangeOrAddOrder });\n\n      this.startPoll();\n    }\n  }, {\n    key: 'componentWillUnmount',\n    value: function componentWillUnmount() {\n      clearInterval(this.polling);\n    }\n  }, {\n    key: 'componentWillReceiveProps',\n    value: function componentWillReceiveProps(nextProps) {\n      if (this.props.notifications !== nextProps.notifications) {\n\n        clearInterval(this.polling);\n\n        this.analysisNotifications(nextProps);\n\n        if (nextProps.notifications.isFetching === false) {\n          this.startPoll();\n        }\n      }\n    }\n  }, {\n    key: 'analysisNotifications',\n    value: function analysisNotifications(nextProps) {\n      for (var i = 0; i < nextProps.notifications.data.length; i++) {\n        for (var j = 0; j < this.eventSender.length; j++) {\n          if (this.eventSender[j].dataType == nextProps.notifications.data[i].dataType) this.eventSender[j].action(nextProps.notifications.data[i]);\n        }\n      }\n    }\n  }, {\n    key: 'startPoll',\n    value: function startPoll() {\n      var getNotifications = this.props.notificationsActions.getNotifications;\n      var lastTicks = this.lastTicks;\n\n      clearInterval(this.polling);\n      this.polling = setInterval(function () {\n        getNotifications(lastTicks);\n      }, 5000);\n    }\n  }, {\n    key: 'render',\n    value: function render() {\n      return _react2.default.createElement(\n        'div',\n        null,\n        this.props.children\n      );\n    }\n  }]);\n\n  return AppContainer;\n}(_react.Component);\n\nfunction mapStateToProps(state) {\n  return {\n    notifications: state.notifications\n  };\n}\n\nfunction mapDispatchToProps(dispatch) {\n  return {\n    notificationsActions: (0, _redux.bindActionCreators)(notificationsActions, dispatch),\n    pollingEventManager: (0, _redux.bindActionCreators)(pollingEventManager, dispatch)\n  };\n}\n\nexports.default = (0, _reactRedux.connect)(mapStateToProps, mapDispatchToProps)(AppContainer);//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMjE1LmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2NvbnRhaW5lcnMvQXBwQ29udGFpbmVyLmpzPzQyMDUiLCJ3ZWJwYWNrOi8vLz9kNDFkIl0sInNvdXJjZXNDb250ZW50IjpbImltcG9ydCBSZWFjdCwgeyBDb21wb25lbnQgfSBmcm9tICdyZWFjdCdcclxuaW1wb3J0IHsgY29ubmVjdCB9IGZyb20gJ3JlYWN0LXJlZHV4J1xyXG5pbXBvcnQgeyBiaW5kQWN0aW9uQ3JlYXRvcnMgfSBmcm9tICdyZWR1eCdcclxuXHJcbmltcG9ydCAqIGFzIG5vdGlmaWNhdGlvbnNBY3Rpb25zIGZyb20gJy4uL2FjdGlvbnMvbm90aWZpY2F0aW9ucy9ub3RpZmljYXRpb25zJ1xyXG5pbXBvcnQgKiBhcyBwb2xsaW5nRXZlbnRNYW5hZ2VyIGZyb20gJy4uL2FjdGlvbnMvcG9sbGluZ0V2ZW50TWFuYWdlci9wb2xsaW5nRXZlbnRNYW5hZ2VyJ1xyXG5cclxuY2xhc3MgQXBwQ29udGFpbmVyIGV4dGVuZHMgQ29tcG9uZW50IHtcclxuICBsYXN0VGlja3MgPSAwXHJcbiAgcG9sbGluZyA9IDBcclxuICBldmVudFNlbmRlciA9IFtdXHJcblxyXG4gIGNvbXBvbmVudERpZE1vdW50KCl7XHJcbiAgICB0aGlzLmV2ZW50U2VuZGVyLnB1c2goeyBkYXRhVHlwZTogXCJJdGVtXCIsIGFjdGlvbjogdGhpcy5wcm9wcy5wb2xsaW5nRXZlbnRNYW5hZ2VyLkNoYW5nZU9yQWRkSXRlbSB9KTtcclxuICAgIHRoaXMuZXZlbnRTZW5kZXIucHVzaCh7IGRhdGFUeXBlOiBcIlN1cHBseVwiLCBhY3Rpb246IHRoaXMucHJvcHMucG9sbGluZ0V2ZW50TWFuYWdlci5DaGFuZ2VPckFkZFN1cHBseSB9KTtcclxuICAgIHRoaXMuZXZlbnRTZW5kZXIucHVzaCh7IGRhdGFUeXBlOiBcIk9yZGVyXCIsIGFjdGlvbjogdGhpcy5wcm9wcy5wb2xsaW5nRXZlbnRNYW5hZ2VyLkNoYW5nZU9yQWRkT3JkZXIgfSk7XHJcblxyXG4gICAgdGhpcy5zdGFydFBvbGwoKTtcclxuICB9XHJcblxyXG4gIGNvbXBvbmVudFdpbGxVbm1vdW50KCkge1xyXG4gICAgICBjbGVhckludGVydmFsKHRoaXMucG9sbGluZyk7XHJcbiAgfVxyXG5cclxuICBjb21wb25lbnRXaWxsUmVjZWl2ZVByb3BzKG5leHRQcm9wcyl7XHJcbiAgICBpZiAodGhpcy5wcm9wcy5ub3RpZmljYXRpb25zICE9PSBuZXh0UHJvcHMubm90aWZpY2F0aW9ucyl7XHJcblxyXG4gICAgICBjbGVhckludGVydmFsKHRoaXMucG9sbGluZyk7XHJcblxyXG4gICAgICB0aGlzLmFuYWx5c2lzTm90aWZpY2F0aW9ucyhuZXh0UHJvcHMpO1xyXG5cclxuICAgICAgaWYgKG5leHRQcm9wcy5ub3RpZmljYXRpb25zLmlzRmV0Y2hpbmcgPT09IGZhbHNlKXtcclxuICAgICAgICB0aGlzLnN0YXJ0UG9sbCgpO1xyXG4gICAgICB9XHJcbiAgICB9XHJcbiAgfVxyXG5cclxuICBhbmFseXNpc05vdGlmaWNhdGlvbnMobmV4dFByb3BzKXtcclxuICAgIGZvciAobGV0IGkgPSAwOyBpIDwgbmV4dFByb3BzLm5vdGlmaWNhdGlvbnMuZGF0YS5sZW5ndGg7IGkrKyl7XHJcbiAgICAgIGZvciAobGV0IGogPSAwOyBqIDwgdGhpcy5ldmVudFNlbmRlci5sZW5ndGg7IGorKyl7XHJcbiAgICAgICAgaWYgKHRoaXMuZXZlbnRTZW5kZXJbal0uZGF0YVR5cGUgPT0gbmV4dFByb3BzLm5vdGlmaWNhdGlvbnMuZGF0YVtpXS5kYXRhVHlwZSlcclxuICAgICAgICB0aGlzLmV2ZW50U2VuZGVyW2pdLmFjdGlvbihuZXh0UHJvcHMubm90aWZpY2F0aW9ucy5kYXRhW2ldKVxyXG4gICAgICB9XHJcbiAgICB9XHJcbiAgfVxyXG5cclxuICBzdGFydFBvbGwoKXtcclxuICAgIGxldCBnZXROb3RpZmljYXRpb25zID0gdGhpcy5wcm9wcy5ub3RpZmljYXRpb25zQWN0aW9ucy5nZXROb3RpZmljYXRpb25zO1xyXG4gICAgbGV0IGxhc3RUaWNrcyA9IHRoaXMubGFzdFRpY2tzO1xyXG5cclxuICAgIGNsZWFySW50ZXJ2YWwodGhpcy5wb2xsaW5nKTtcclxuICAgIHRoaXMucG9sbGluZyA9IHNldEludGVydmFsKCgpID0+IHtcclxuICAgICAgZ2V0Tm90aWZpY2F0aW9ucyhsYXN0VGlja3MpO1xyXG4gICAgfSwgNTAwMCk7XHJcbiAgfVxyXG5cclxuICByZW5kZXIoKXtcclxuICAgIHJldHVybiA8ZGl2Pnt0aGlzLnByb3BzLmNoaWxkcmVufTwvZGl2PlxyXG4gIH1cclxufVxyXG5cclxuXHJcbmZ1bmN0aW9uIG1hcFN0YXRlVG9Qcm9wcyAoc3RhdGUpIHtcclxuICByZXR1cm4ge1xyXG4gICAgbm90aWZpY2F0aW9uczogc3RhdGUubm90aWZpY2F0aW9uc1xyXG4gIH1cclxufVxyXG5cclxuZnVuY3Rpb24gbWFwRGlzcGF0Y2hUb1Byb3BzKGRpc3BhdGNoKSB7XHJcbiAgcmV0dXJuIHtcclxuICAgIG5vdGlmaWNhdGlvbnNBY3Rpb25zOiBiaW5kQWN0aW9uQ3JlYXRvcnMobm90aWZpY2F0aW9uc0FjdGlvbnMsIGRpc3BhdGNoKSxcclxuICAgIHBvbGxpbmdFdmVudE1hbmFnZXI6IGJpbmRBY3Rpb25DcmVhdG9ycyhwb2xsaW5nRXZlbnRNYW5hZ2VyLCBkaXNwYXRjaClcclxuICB9XHJcbn1cclxuXHJcbmV4cG9ydCBkZWZhdWx0IGNvbm5lY3QobWFwU3RhdGVUb1Byb3BzLCBtYXBEaXNwYXRjaFRvUHJvcHMpKEFwcENvbnRhaW5lcilcclxuXG5cblxuLyoqIFdFQlBBQ0sgRk9PVEVSICoqXG4gKiogLi9zcmMvY29udGFpbmVycy9BcHBDb250YWluZXIuanNcbiAqKi8iLCJ1bmRlZmluZWRcblxuXG4vKiogV0VCUEFDSyBGT09URVIgKipcbiAqKiBcbiAqKi8iXSwibWFwcGluZ3MiOiI7Ozs7Ozs7O0FBQUE7QUFDQTs7O0FBQUE7QUFDQTtBQUFBO0FBQ0E7QUFDQTtBQUNBO0FBREE7QUFDQTtBQUFBO0FBQ0E7QUFEQTtBQUNBOzs7Ozs7Ozs7OztBQ0NBOzs7Ozs7Ozs7Ozs7OztBQUNBOzs7OztBQUlBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOzs7QUFFQTtBQUNBO0FBQ0E7OztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFFQTtBQUNBO0FBQ0E7OztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7O0FBRUE7QUFDQTtBQUFBO0FBQUE7QUFBQTtBQUFBO0FBQ0E7Ozs7OztBQUlBO0FBQ0E7QUFDQTtBQURBO0FBR0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBRkE7QUFJQTtBQUNBOyIsInNvdXJjZVJvb3QiOiIifQ==");

/***/ }

})