webpackHotUpdate(0,{

/***/ 200:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\nexports.getNotifications = getNotifications;\n\nvar _notifications = __webpack_require__(123);\n\nvar _NotificationsRepository = __webpack_require__(233);\n\nvar _NotificationsRepository2 = _interopRequireDefault(_NotificationsRepository);\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction getNotifications(ticks) {\n\n  return function (dispatch) {\n    dispatch({\n      type: _notifications.GET_NOTIFICATIONS_REQUEST,\n      payload: {}\n    });\n\n    new _NotificationsRepository2.default().getNotifications(ticks, function (data) {\n\n      if (data == null || data.length == 0) {\n        dispatch({\n          type: _notifications.GET_NOTIFICATIONS_FAILED,\n          payload: {}\n        });\n      } else {\n        dispatch({\n          type: _notifications.GET_NOTIFICATIONS_SUCCESS,\n          payload: data\n        });\n      }\n    });\n  };\n}//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMjAwLmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2FjdGlvbnMvbm90aWZpY2F0aW9ucy9ub3RpZmljYXRpb25zLmpzPzBkM2UiLCJ3ZWJwYWNrOi8vLz9kNDFkIl0sInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7XHJcbiAgR0VUX05PVElGSUNBVElPTlNfUkVRVUVTVCxcclxuICBHRVRfTk9USUZJQ0FUSU9OU19TVUNDRVNTLFxyXG4gIEdFVF9OT1RJRklDQVRJT05TX0ZBSUxFRCxcclxufSBmcm9tICcuLi8uLi9jb25zdGFudHMvbm90aWZpY2F0aW9ucy9ub3RpZmljYXRpb25zJ1xyXG5cclxuaW1wb3J0IE5vdGlmaWNhdGlvbnNSZXBvc2l0b3J5IGZyb20gJy4uLy4uL3JlcG9zaXRvcmllcy9Ob3RpZmljYXRpb25zUmVwb3NpdG9yeSdcclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBnZXROb3RpZmljYXRpb25zKHRpY2tzKSB7XHJcblxyXG4gIHJldHVybiAoZGlzcGF0Y2gpID0+IHtcclxuICAgIGRpc3BhdGNoKHtcclxuICAgICAgdHlwZTogR0VUX05PVElGSUNBVElPTlNfUkVRVUVTVCxcclxuICAgICAgcGF5bG9hZDoge31cclxuICAgIH0pXHJcblxyXG4gICAgbmV3IE5vdGlmaWNhdGlvbnNSZXBvc2l0b3J5KCkuZ2V0Tm90aWZpY2F0aW9ucyh0aWNrcywgKGRhdGEpID0+IHtcclxuXHJcbiAgICAgIGlmIChkYXRhID09IG51bGwgfHwgZGF0YS5sZW5ndGggPT0gMCl7XHJcbiAgICAgICAgZGlzcGF0Y2goe1xyXG4gICAgICAgICAgdHlwZTogR0VUX05PVElGSUNBVElPTlNfRkFJTEVELFxyXG4gICAgICAgICAgcGF5bG9hZDoge31cclxuICAgICAgICB9KVxyXG4gICAgICB9XHJcbiAgICAgIGVsc2V7XHJcbiAgICAgICAgZGlzcGF0Y2goe1xyXG4gICAgICAgICAgdHlwZTogR0VUX05PVElGSUNBVElPTlNfU1VDQ0VTUyxcclxuICAgICAgICAgIHBheWxvYWQ6IGRhdGFcclxuICAgICAgICB9KVxyXG4gICAgICB9XHJcbiAgICB9KVxyXG4gIH1cclxufVxyXG5cblxuXG4vKiogV0VCUEFDSyBGT09URVIgKipcbiAqKiAuL3NyYy9hY3Rpb25zL25vdGlmaWNhdGlvbnMvbm90aWZpY2F0aW9ucy5qc1xuICoqLyIsInVuZGVmaW5lZFxuXG5cbi8qKiBXRUJQQUNLIEZPT1RFUiAqKlxuICoqIFxuICoqLyJdLCJtYXBwaW5ncyI6Ijs7Ozs7QUFRQTtBQUNBO0FBVEE7QUFDQTtBQUtBO0FBQ0E7Ozs7O0FBQ0E7QUFDQTtBQ0NBO0FBQ0E7QUFDQTtBQUNBO0FBRkE7QUFDQTtBQUlBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUZBO0FBSUE7QUFFQTtBQUNBO0FBQ0E7QUFGQTtBQUlBO0FBQ0E7QUFDQTsiLCJzb3VyY2VSb290IjoiIn0=");

/***/ }

})