webpackHotUpdate(0,{

/***/ 141:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\nexports.addClient = addClient;\nexports.addEmployee = addEmployee;\nexports.getProviders = getProviders;\nexports.getClients = getClients;\nexports.addProvider = addProvider;\n\nvar _admin = __webpack_require__(83);\n\nvar _AccountRepository = __webpack_require__(86);\n\nvar _AccountRepository2 = _interopRequireDefault(_AccountRepository);\n\nvar _ActorsRepository = __webpack_require__(326);\n\nvar _ActorsRepository2 = _interopRequireDefault(_ActorsRepository);\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction addClient(username) {\n\n  return function (dispatch) {\n    dispatch({\n      type: _admin.ADD_CLIENT_REQUEST,\n      payload: {}\n    });\n\n    new _AccountRepository2.default().addClientRole(username, function (data) {\n      if (data != null) {\n        dispatch({\n          type: _admin.ADD_EMPLOYEE_SUCCESS,\n          payload: data\n        });\n      } else {\n        dispatch({\n          type: _admin.ADD_CLIENT_FAILED,\n          payload: { errorMessage: \"error, repeat again\" }\n        });\n      }\n    });\n  };\n}\n\nfunction addEmployee(username) {\n\n  return function (dispatch) {\n    dispatch({\n      type: _admin.ADD_EMPLOYEE_REQUEST,\n      payload: {}\n    });\n\n    new _AccountRepository2.default().addEmployeeRole(username, function (data) {\n      if (data != null) {\n        dispatch({\n          type: _admin.ADD_EMPLOYEE_SUCCESS,\n          payload: data\n        });\n      } else {\n        dispatch({\n          type: _admin.ADD_EMPLOYEE_FAILED,\n          payload: { errorMessage: \"error, repeat again\" }\n        });\n      }\n    });\n  };\n}\n\nfunction getProviders() {\n\n  return function (dispatch) {\n    dispatch({\n      type: _admin.GET_PROVIDERS_REQUEST,\n      payload: {}\n    });\n\n    new _ActorsRepository2.default().getProviders(function (data) {\n      if (data != null) {\n        dispatch({\n          type: _admin.GET_PROVIDERS_SUCCESS,\n          payload: data\n        });\n      } else {\n        dispatch({\n          type: _admin.GET_PROVIDERS_FAILED,\n          payload: { errorMessage: \"error, repeat again\" }\n        });\n      }\n    });\n  };\n}\n\nfunction getClients() {\n  return function (dispatch) {\n    dispatch({\n      type: _admin.GET_CLIENTS_REQUEST,\n      payload: {}\n    });\n\n    new _ActorsRepository2.default().getClients(function (data) {\n      if (data != null) {\n        dispatch({\n          type: _admin.GET_CLIENTS_SUCCESS,\n          payload: data\n        });\n      } else {\n        dispatch({\n          type: _admin.GET_CLIENTS_FAILED,\n          payload: { errorMessage: \"error, repeat again\" }\n        });\n      }\n    });\n  };\n}\n\nfunction addProvider(provider) {\n  return function (dispatch) {\n    dispatch({\n      type: _admin.ADD_PROVIDER_REQUEST,\n      payload: {}\n    });\n\n    new _ActorsRepository2.default().addProvder(function () {\n      if (data != null) {\n        dispatch({\n          type: _admin.ADD_PROVIDER_SUCCESS,\n          payload: {}\n        });\n      }\n    });\n  };\n}//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMTQxLmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2FjdGlvbnMvcHJvZmlsZS9hZG1pbi5qcz8zZjZjIiwid2VicGFjazovLy8/ZDQxZCJdLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQge1xyXG4gIEFERF9FTVBMT1lFRV9SRVFVRVNULFxyXG4gIEFERF9FTVBMT1lFRV9TVUNDRVNTLFxyXG4gIEFERF9FTVBMT1lFRV9GQUlMRUQsXHJcblxyXG4gIEFERF9DTElFTlRfUkVRVUVTVCxcclxuICBBRERfQ0xJRU5UX1NVQ0NFU1MsXHJcbiAgQUREX0NMSUVOVF9GQUlMRUQsXHJcblxyXG4gIEdFVF9QUk9WSURFUlNfUkVRVUVTVCxcclxuICBHRVRfUFJPVklERVJTX1NVQ0NFU1MsXHJcbiAgR0VUX1BST1ZJREVSU19GQUlMRUQsXHJcblxyXG4gIEdFVF9DTElFTlRTX1JFUVVFU1QsXHJcbiAgR0VUX0NMSUVOVFNfU1VDQ0VTUyxcclxuICBHRVRfQ0xJRU5UU19GQUlMRUQsXHJcblxyXG4gIEFERF9QUk9WSURFUl9SRVFVRVNULFxyXG4gIEFERF9QUk9WSURFUl9TVUNDRVNTXHJcbn0gZnJvbSAgJy4uLy4uL2NvbnN0YW50cy9wcm9maWxlL2FkbWluJ1xyXG5cclxuaW1wb3J0IEFjY291bnRSZXBvc2l0b3J5IGZyb20gJy4uLy4uL3JlcG9zaXRvcmllcy9BY2NvdW50UmVwb3NpdG9yeSdcclxuXHJcbmltcG9ydCBBY3RvcnNSZXBvc2l0b3J5IGZyb20gJy4uLy4uL3JlcG9zaXRvcmllcy9BY3RvcnNSZXBvc2l0b3J5J1xyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGFkZENsaWVudCh1c2VybmFtZSkge1xyXG5cclxuICByZXR1cm4gKGRpc3BhdGNoKSA9PiB7XHJcbiAgICBkaXNwYXRjaCh7XHJcbiAgICAgIHR5cGU6IEFERF9DTElFTlRfUkVRVUVTVCxcclxuICAgICAgcGF5bG9hZDoge31cclxuICAgIH0pXHJcblxyXG4gICAgbmV3IEFjY291bnRSZXBvc2l0b3J5KCkuYWRkQ2xpZW50Um9sZSh1c2VybmFtZSwgKGRhdGEpID0+IHtcclxuICAgICAgaWYgKGRhdGEgIT0gbnVsbCl7XHJcbiAgICAgICAgZGlzcGF0Y2goe1xyXG4gICAgICAgICAgdHlwZTogQUREX0VNUExPWUVFX1NVQ0NFU1MsXHJcbiAgICAgICAgICBwYXlsb2FkOiBkYXRhXHJcbiAgICAgICAgfSlcclxuICAgICAgfVxyXG4gICAgICBlbHNle1xyXG4gICAgICAgIGRpc3BhdGNoKHtcclxuICAgICAgICAgIHR5cGU6IEFERF9DTElFTlRfRkFJTEVELFxyXG4gICAgICAgICAgcGF5bG9hZDoge2Vycm9yTWVzc2FnZTogXCJlcnJvciwgcmVwZWF0IGFnYWluXCJ9XHJcbiAgICAgICAgfSlcclxuICAgICAgfVxyXG4gICAgfSk7XHJcbiAgfVxyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gYWRkRW1wbG95ZWUodXNlcm5hbWUpIHtcclxuXHJcbiAgcmV0dXJuIChkaXNwYXRjaCkgPT4ge1xyXG4gICAgZGlzcGF0Y2goe1xyXG4gICAgICB0eXBlOiBBRERfRU1QTE9ZRUVfUkVRVUVTVCxcclxuICAgICAgcGF5bG9hZDoge31cclxuICAgIH0pXHJcblxyXG4gICAgbmV3IEFjY291bnRSZXBvc2l0b3J5KCkuYWRkRW1wbG95ZWVSb2xlKHVzZXJuYW1lLCAoZGF0YSkgPT4ge1xyXG4gICAgICBpZiAoZGF0YSAhPSBudWxsKXtcclxuICAgICAgICBkaXNwYXRjaCh7XHJcbiAgICAgICAgICB0eXBlOiBBRERfRU1QTE9ZRUVfU1VDQ0VTUyxcclxuICAgICAgICAgIHBheWxvYWQ6IGRhdGFcclxuICAgICAgICB9KVxyXG4gICAgICB9XHJcbiAgICAgIGVsc2V7XHJcbiAgICAgICAgZGlzcGF0Y2goe1xyXG4gICAgICAgICAgdHlwZTogQUREX0VNUExPWUVFX0ZBSUxFRCxcclxuICAgICAgICAgIHBheWxvYWQ6IHtlcnJvck1lc3NhZ2U6IFwiZXJyb3IsIHJlcGVhdCBhZ2FpblwifVxyXG4gICAgICAgIH0pXHJcbiAgICAgIH1cclxuICAgIH0pO1xyXG4gIH1cclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGdldFByb3ZpZGVycygpIHtcclxuXHJcbiAgcmV0dXJuIChkaXNwYXRjaCkgPT4ge1xyXG4gICAgZGlzcGF0Y2goe1xyXG4gICAgICB0eXBlOiBHRVRfUFJPVklERVJTX1JFUVVFU1QsXHJcbiAgICAgIHBheWxvYWQ6IHt9XHJcbiAgICB9KVxyXG5cclxuICAgIG5ldyBBY3RvcnNSZXBvc2l0b3J5KCkuZ2V0UHJvdmlkZXJzKChkYXRhKSA9PiB7XHJcbiAgICAgIGlmIChkYXRhICE9IG51bGwpe1xyXG4gICAgICAgIGRpc3BhdGNoKHtcclxuICAgICAgICAgIHR5cGU6IEdFVF9QUk9WSURFUlNfU1VDQ0VTUyxcclxuICAgICAgICAgIHBheWxvYWQ6IGRhdGFcclxuICAgICAgICB9KVxyXG4gICAgICB9XHJcbiAgICAgIGVsc2V7XHJcbiAgICAgICAgZGlzcGF0Y2goe1xyXG4gICAgICAgICAgdHlwZTogR0VUX1BST1ZJREVSU19GQUlMRUQsXHJcbiAgICAgICAgICBwYXlsb2FkOiB7ZXJyb3JNZXNzYWdlOiBcImVycm9yLCByZXBlYXQgYWdhaW5cIn1cclxuICAgICAgICB9KVxyXG4gICAgICB9XHJcbiAgICB9KVxyXG4gIH1cclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGdldENsaWVudHMoKSB7XHJcbiAgcmV0dXJuIChkaXNwYXRjaCkgPT4ge1xyXG4gICAgZGlzcGF0Y2goe1xyXG4gICAgICB0eXBlOiBHRVRfQ0xJRU5UU19SRVFVRVNULFxyXG4gICAgICBwYXlsb2FkOiB7fVxyXG4gICAgfSlcclxuXHJcbiAgICBuZXcgQWN0b3JzUmVwb3NpdG9yeSgpLmdldENsaWVudHMoKGRhdGEpID0+IHtcclxuICAgICAgaWYgKGRhdGEgIT0gbnVsbCl7XHJcbiAgICAgICAgZGlzcGF0Y2goe1xyXG4gICAgICAgICAgdHlwZTogR0VUX0NMSUVOVFNfU1VDQ0VTUyxcclxuICAgICAgICAgIHBheWxvYWQ6IGRhdGFcclxuICAgICAgICB9KVxyXG4gICAgICB9XHJcbiAgICAgIGVsc2V7XHJcbiAgICAgICAgZGlzcGF0Y2goe1xyXG4gICAgICAgICAgdHlwZTogR0VUX0NMSUVOVFNfRkFJTEVELFxyXG4gICAgICAgICAgcGF5bG9hZDoge2Vycm9yTWVzc2FnZTogXCJlcnJvciwgcmVwZWF0IGFnYWluXCJ9XHJcbiAgICAgICAgfSlcclxuICAgICAgfVxyXG4gICAgfSlcclxuICB9XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBhZGRQcm92aWRlcihwcm92aWRlcikge1xyXG4gIHJldHVybiAoZGlzcGF0Y2gpID0+IHtcclxuICAgIGRpc3BhdGNoKHtcclxuICAgICAgdHlwZTogQUREX1BST1ZJREVSX1JFUVVFU1QsXHJcbiAgICAgIHBheWxvYWQ6IHt9XHJcbiAgICB9KVxyXG5cclxuICAgIG5ldyBBY3RvcnNSZXBvc2l0b3J5KCkuYWRkUHJvdmRlcigoKSA9PiB7XHJcbiAgICAgIGlmIChkYXRhICE9IG51bGwpe1xyXG4gICAgICAgIGRpc3BhdGNoKHtcclxuICAgICAgICAgIHR5cGU6IEFERF9QUk9WSURFUl9TVUNDRVNTLFxyXG4gICAgICAgICAgcGF5bG9hZDoge31cclxuICAgICAgICB9KVxyXG4gICAgICB9XHJcbiAgICB9KVxyXG4gIH1cclxufVxyXG5cblxuXG4vKiogV0VCUEFDSyBGT09URVIgKipcbiAqKiAuL3NyYy9hY3Rpb25zL3Byb2ZpbGUvYWRtaW4uanNcbiAqKi8iLCJ1bmRlZmluZWRcblxuXG4vKiogV0VCUEFDSyBGT09URVIgKipcbiAqKiBcbiAqKi8iXSwibWFwcGluZ3MiOiI7Ozs7O0FBeUJBO0FBeUJBO0FDeUJBO0FBeUJBO0FBd0JBO0FBQ0E7QUE3SEE7QUFDQTtBQW9CQTtBQUNBOzs7QUFDQTtBQUNBOzs7OztBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUZBO0FBQ0E7QUFJQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBRkE7QUFJQTtBQUVBO0FBQ0E7QUFDQTtBQUZBO0FBSUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUZBO0FBQ0E7QUFJQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBRkE7QUFJQTtBQUVBO0FBQ0E7QUFDQTtBQUZBO0FBSUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUZBO0FBQ0E7QUFJQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBRkE7QUFJQTtBQUVBO0FBQ0E7QUFDQTtBQUZBO0FBSUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFGQTtBQUNBO0FBSUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUZBO0FBSUE7QUFFQTtBQUNBO0FBQ0E7QUFGQTtBQUlBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBRkE7QUFDQTtBQUlBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFGQTtBQUlBO0FBQ0E7QUFDQTsiLCJzb3VyY2VSb290IjoiIn0=");

/***/ }

})