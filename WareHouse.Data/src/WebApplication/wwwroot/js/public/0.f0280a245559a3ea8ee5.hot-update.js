webpackHotUpdate(0,{

/***/ 141:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\nexports.addClient = addClient;\nexports.addEmployee = addEmployee;\nexports.getproviders = getproviders;\n\nvar _admin = __webpack_require__(83);\n\nvar _AccountRepository = __webpack_require__(86);\n\nvar _AccountRepository2 = _interopRequireDefault(_AccountRepository);\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction addClient(username) {\n\n  return function (dispatch) {\n    dispatch({\n      type: _admin.ADD_CLIENT_REQUEST,\n      payload: {}\n    });\n\n    new _AccountRepository2.default().addClientRole(username, function (data) {\n      if (data != null) {\n        dispatch({\n          type: _admin.ADD_EMPLOYEE_SUCCESS,\n          payload: data\n        });\n      } else {\n        dispatch({\n          type: _admin.ADD_CLIENT_FAILED,\n          payload: { errorMessage: \"error, repeat again\" }\n        });\n      }\n    });\n  };\n}\n\nfunction addEmployee(username) {\n\n  return function (dispatch) {\n    dispatch({\n      type: _admin.ADD_EMPLOYEE_REQUEST,\n      payload: {}\n    });\n\n    new _AccountRepository2.default().addEmployeeRole(username, function (data) {\n      if (data != null) {\n        dispatch({\n          type: _admin.ADD_EMPLOYEE_SUCCESS,\n          payload: data\n        });\n      } else {\n        dispatch({\n          type: _admin.ADD_EMPLOYEE_FAILED,\n          payload: { errorMessage: \"error, repeat again\" }\n        });\n      }\n    });\n  };\n}\n\nfunction getproviders(username) {\n\n  return function (dispatch) {\n    dispatch({\n      type: _admin.ADD_EMPLOYEE_REQUEST,\n      payload: {}\n    });\n\n    new _AccountRepository2.default().addEmployeeRole(username, function (data) {\n      if (data != null) {\n        dispatch({\n          type: _admin.ADD_EMPLOYEE_SUCCESS,\n          payload: data\n        });\n      } else {\n        dispatch({\n          type: _admin.ADD_EMPLOYEE_FAILED,\n          payload: { errorMessage: \"error, repeat again\" }\n        });\n      }\n    });\n  };\n}//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMTQxLmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2FjdGlvbnMvcHJvZmlsZS9hZG1pbi5qcz8zZjZjIiwid2VicGFjazovLy8/ZDQxZCJdLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQge1xyXG4gIEFERF9FTVBMT1lFRV9SRVFVRVNULFxyXG4gIEFERF9FTVBMT1lFRV9TVUNDRVNTLFxyXG4gIEFERF9FTVBMT1lFRV9GQUlMRUQsXHJcblxyXG4gIEFERF9DTElFTlRfUkVRVUVTVCxcclxuICBBRERfQ0xJRU5UX1NVQ0NFU1MsXHJcbiAgQUREX0NMSUVOVF9GQUlMRURcclxufSBmcm9tICAnLi4vLi4vY29uc3RhbnRzL3Byb2ZpbGUvYWRtaW4nXHJcblxyXG5pbXBvcnQgQWNjb3VudFJlcG9zaXRvcnkgZnJvbSAnLi4vLi4vcmVwb3NpdG9yaWVzL0FjY291bnRSZXBvc2l0b3J5J1xyXG5cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBhZGRDbGllbnQodXNlcm5hbWUpIHtcclxuXHJcbiAgcmV0dXJuIChkaXNwYXRjaCkgPT4ge1xyXG4gICAgZGlzcGF0Y2goe1xyXG4gICAgICB0eXBlOiBBRERfQ0xJRU5UX1JFUVVFU1QsXHJcbiAgICAgIHBheWxvYWQ6IHt9XHJcbiAgICB9KVxyXG5cclxuICAgIG5ldyBBY2NvdW50UmVwb3NpdG9yeSgpLmFkZENsaWVudFJvbGUodXNlcm5hbWUsIChkYXRhKSA9PiB7XHJcbiAgICAgIGlmIChkYXRhICE9IG51bGwpe1xyXG4gICAgICAgIGRpc3BhdGNoKHtcclxuICAgICAgICAgIHR5cGU6IEFERF9FTVBMT1lFRV9TVUNDRVNTLFxyXG4gICAgICAgICAgcGF5bG9hZDogZGF0YVxyXG4gICAgICAgIH0pXHJcbiAgICAgIH1cclxuICAgICAgZWxzZXtcclxuICAgICAgICBkaXNwYXRjaCh7XHJcbiAgICAgICAgICB0eXBlOiBBRERfQ0xJRU5UX0ZBSUxFRCxcclxuICAgICAgICAgIHBheWxvYWQ6IHtlcnJvck1lc3NhZ2U6IFwiZXJyb3IsIHJlcGVhdCBhZ2FpblwifVxyXG4gICAgICAgIH0pXHJcbiAgICAgIH1cclxuICAgIH0pO1xyXG4gIH1cclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGFkZEVtcGxveWVlKHVzZXJuYW1lKSB7XHJcblxyXG4gIHJldHVybiAoZGlzcGF0Y2gpID0+IHtcclxuICAgIGRpc3BhdGNoKHtcclxuICAgICAgdHlwZTogQUREX0VNUExPWUVFX1JFUVVFU1QsXHJcbiAgICAgIHBheWxvYWQ6IHt9XHJcbiAgICB9KVxyXG5cclxuICAgIG5ldyBBY2NvdW50UmVwb3NpdG9yeSgpLmFkZEVtcGxveWVlUm9sZSh1c2VybmFtZSwgKGRhdGEpID0+IHtcclxuICAgICAgaWYgKGRhdGEgIT0gbnVsbCl7XHJcbiAgICAgICAgZGlzcGF0Y2goe1xyXG4gICAgICAgICAgdHlwZTogQUREX0VNUExPWUVFX1NVQ0NFU1MsXHJcbiAgICAgICAgICBwYXlsb2FkOiBkYXRhXHJcbiAgICAgICAgfSlcclxuICAgICAgfVxyXG4gICAgICBlbHNle1xyXG4gICAgICAgIGRpc3BhdGNoKHtcclxuICAgICAgICAgIHR5cGU6IEFERF9FTVBMT1lFRV9GQUlMRUQsXHJcbiAgICAgICAgICBwYXlsb2FkOiB7ZXJyb3JNZXNzYWdlOiBcImVycm9yLCByZXBlYXQgYWdhaW5cIn1cclxuICAgICAgICB9KVxyXG4gICAgICB9XHJcbiAgICB9KTtcclxuICB9XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBnZXRwcm92aWRlcnModXNlcm5hbWUpIHtcclxuXHJcbiAgcmV0dXJuIChkaXNwYXRjaCkgPT4ge1xyXG4gICAgZGlzcGF0Y2goe1xyXG4gICAgICB0eXBlOiBBRERfRU1QTE9ZRUVfUkVRVUVTVCxcclxuICAgICAgcGF5bG9hZDoge31cclxuICAgIH0pXHJcblxyXG4gICAgbmV3IEFjY291bnRSZXBvc2l0b3J5KCkuYWRkRW1wbG95ZWVSb2xlKHVzZXJuYW1lLCAoZGF0YSkgPT4ge1xyXG4gICAgICBpZiAoZGF0YSAhPSBudWxsKXtcclxuICAgICAgICBkaXNwYXRjaCh7XHJcbiAgICAgICAgICB0eXBlOiBBRERfRU1QTE9ZRUVfU1VDQ0VTUyxcclxuICAgICAgICAgIHBheWxvYWQ6IGRhdGFcclxuICAgICAgICB9KVxyXG4gICAgICB9XHJcbiAgICAgIGVsc2V7XHJcbiAgICAgICAgZGlzcGF0Y2goe1xyXG4gICAgICAgICAgdHlwZTogQUREX0VNUExPWUVFX0ZBSUxFRCxcclxuICAgICAgICAgIHBheWxvYWQ6IHtlcnJvck1lc3NhZ2U6IFwiZXJyb3IsIHJlcGVhdCBhZ2FpblwifVxyXG4gICAgICAgIH0pXHJcbiAgICAgIH1cclxuICAgIH0pO1xyXG4gIH1cclxufVxyXG5cblxuXG4vKiogV0VCUEFDSyBGT09URVIgKipcbiAqKiAuL3NyYy9hY3Rpb25zL3Byb2ZpbGUvYWRtaW4uanNcbiAqKi8iLCJ1bmRlZmluZWRcblxuXG4vKiogV0VCUEFDSyBGT09URVIgKipcbiAqKiBcbiAqKi8iXSwibWFwcGluZ3MiOiI7Ozs7O0FBYUE7QUF5QkE7QUN5QkE7QUFDQTtBQWhFQTtBQUNBO0FBU0E7QUFDQTs7Ozs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFGQTtBQUNBO0FBSUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUZBO0FBSUE7QUFFQTtBQUNBO0FBQ0E7QUFGQTtBQUlBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFGQTtBQUNBO0FBSUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUZBO0FBSUE7QUFFQTtBQUNBO0FBQ0E7QUFGQTtBQUlBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFGQTtBQUNBO0FBSUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUZBO0FBSUE7QUFFQTtBQUNBO0FBQ0E7QUFGQTtBQUlBO0FBQ0E7QUFDQTsiLCJzb3VyY2VSb290IjoiIn0=");

/***/ }

})