webpackHotUpdate(0,{

/***/ 160:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\n\nvar _redux = __webpack_require__(19);\n\nvar _about = __webpack_require__(162);\n\nvar _about2 = _interopRequireDefault(_about);\n\nvar _admin = __webpack_require__(163);\n\nvar _admin2 = _interopRequireDefault(_admin);\n\nvar _orders = __webpack_require__(161);\n\nvar _orders2 = _interopRequireDefault(_orders);\n\nvar _supplies = __webpack_require__(164);\n\nvar _supplies2 = _interopRequireDefault(_supplies);\n\nvar _warehouseItems = __webpack_require__(165);\n\nvar _warehouseItems2 = _interopRequireDefault(_warehouseItems);\n\nvar _items = __webpack_require__(330);\n\nvar _items2 = _interopRequireDefault(_items);\n\nvar _reactRouterRedux = __webpack_require__(121);\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nexports.default = (0, _redux.combineReducers)({\n  about: _about2.default,\n  orders: _orders2.default,\n  supplies: _supplies2.default,\n  admin: _admin2.default,\n  page: _warehouseItems2.default,\n  items: _items2.default,\n  routing: _reactRouterRedux.routerReducer\n});//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMTYwLmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL3JlZHVjZXJzL2luZGV4LmpzPzBhMTEiLCJ3ZWJwYWNrOi8vLz9kNDFkIl0sInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IGNvbWJpbmVSZWR1Y2VycyB9IGZyb20gJ3JlZHV4J1xyXG5cclxuaW1wb3J0IGFib3V0IGZyb20gJy4vcHJvZmlsZS9hYm91dCdcclxuaW1wb3J0IGFkbWluIGZyb20gJy4vcHJvZmlsZS9hZG1pbidcclxuaW1wb3J0IG9yZGVycyBmcm9tICcuL29yZGVycy9vcmRlcnMnXHJcbmltcG9ydCBzdXBwbGllcyBmcm9tICcuL3N1cHBsaWVzL3N1cHBsaWVzJ1xyXG5pbXBvcnQgcGFnZSBmcm9tICcuL3dhcmVob3VzZUl0ZW1zL3dhcmVob3VzZUl0ZW1zJ1xyXG5pbXBvcnQgaXRlbXMgZnJvbSAnLi9pdGVtcy9pdGVtcydcclxuaW1wb3J0IHsgcm91dGVyUmVkdWNlciB9IGZyb20gJ3JlYWN0LXJvdXRlci1yZWR1eCdcclxuXHJcbmV4cG9ydCBkZWZhdWx0IGNvbWJpbmVSZWR1Y2Vycyh7XHJcbiAgYWJvdXQsXHJcbiAgb3JkZXJzLFxyXG4gIHN1cHBsaWVzLFxyXG4gIGFkbWluLFxyXG4gIHBhZ2UsXHJcbiAgaXRlbXMsXHJcbiAgcm91dGluZzogcm91dGVyUmVkdWNlclxyXG59KVxyXG5cblxuXG4vKiogV0VCUEFDSyBGT09URVIgKipcbiAqKiAuL3NyYy9yZWR1Y2Vycy9pbmRleC5qc1xuICoqLyIsInVuZGVmaW5lZFxuXG5cbi8qKiBXRUJQQUNLIEZPT1RFUiAqKlxuICoqIFxuICoqLyJdLCJtYXBwaW5ncyI6Ijs7Ozs7O0FBQUE7QUFDQTtBQUNBO0FBQ0E7OztBQUFBO0FBQ0E7OztBQUFBO0FBQ0E7OztBQUFBO0FBQ0E7OztBQUFBO0FBQ0E7OztBQUFBO0FBQ0E7OztBQUFBO0FBQ0E7OztBQUNBO0FBQ0E7QUFDQTtBQ0NBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFQQSIsInNvdXJjZVJvb3QiOiIifQ==");

/***/ },

/***/ 330:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\nexports.default = items;\n\nvar _items = __webpack_require__(328);\n\nvar initialState = {\n  items: [],\n  errorMessage: null\n};\n\nfunction items() {\n  var state = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : initialState;\n  var action = arguments[1];\n\n  switch (action.type) {\n    case _items.GET_ITEMS_REQUEST:\n      return Object.assign({}, state, {\n        errorMessage: null\n      });\n\n    case _items.GET_ITEMS_SUCCESS:\n      return Object.assign({}, state, {\n        items: action.payload,\n        errorMessage: null\n      });\n\n    case _items.GET_ITEMS_FAILED:\n      return Object.assign({}, state, {\n        errorMessage: action.payload.errorMessage\n      });\n\n    default:\n      return state;\n  }\n}//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMzMwLmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL3JlZHVjZXJzL2l0ZW1zL2l0ZW1zLmpzP2RjN2IiLCJ3ZWJwYWNrOi8vLz9kNDFkIl0sInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7XHJcbiAgR0VUX0lURU1TX1JFUVVFU1QsXHJcbiAgR0VUX0lURU1TX1NVQ0NFU1MsXHJcbiAgR0VUX0lURU1TX0ZBSUxFRFxyXG59IGZyb20gJy4uLy4uL2NvbnN0YW50cy9pdGVtcy9pdGVtcydcclxuXHJcbmNvbnN0IGluaXRpYWxTdGF0ZSA9IHtcclxuICBpdGVtczogW10sXHJcbiAgZXJyb3JNZXNzYWdlOiBudWxsXHJcbn1cclxuXHJcbmV4cG9ydCBkZWZhdWx0IGZ1bmN0aW9uIGl0ZW1zKHN0YXRlID0gaW5pdGlhbFN0YXRlLCBhY3Rpb24pIHtcclxuICBzd2l0Y2ggKGFjdGlvbi50eXBlKSB7XHJcbiAgIGNhc2UgR0VUX0lURU1TX1JFUVVFU1Q6XHJcbiAgICAgcmV0dXJuIE9iamVjdC5hc3NpZ24oe30sIHN0YXRlLCB7XHJcbiAgICAgICBlcnJvck1lc3NhZ2U6IG51bGxcclxuICAgICB9KVxyXG5cclxuICAgY2FzZSBHRVRfSVRFTVNfU1VDQ0VTUzpcclxuICAgICByZXR1cm4gT2JqZWN0LmFzc2lnbih7fSwgc3RhdGUsIHtcclxuICAgICAgIGl0ZW1zOiBhY3Rpb24ucGF5bG9hZCxcclxuICAgICAgIGVycm9yTWVzc2FnZTogbnVsbFxyXG4gICAgIH0pXHJcblxyXG4gICAgY2FzZSBHRVRfSVRFTVNfRkFJTEVEOlxyXG4gICAgICByZXR1cm4gT2JqZWN0LmFzc2lnbih7fSwgc3RhdGUsIHtcclxuICAgICAgICBlcnJvck1lc3NhZ2U6IGFjdGlvbi5wYXlsb2FkLmVycm9yTWVzc2FnZVxyXG4gICAgICB9KVxyXG5cclxuICAgICBkZWZhdWx0OlxyXG4gICAgICAgcmV0dXJuIHN0YXRlO1xyXG4gICB9XHJcbn1cclxuXG5cblxuLyoqIFdFQlBBQ0sgRk9PVEVSICoqXG4gKiogLi9zcmMvcmVkdWNlcnMvaXRlbXMvaXRlbXMuanNcbiAqKi8iLCJ1bmRlZmluZWRcblxuXG4vKiogV0VCUEFDSyBGT09URVIgKipcbiAqKiBcbiAqKi8iXSwibWFwcGluZ3MiOiI7Ozs7O0FBV0E7QUFDQTtBQVpBO0FBQ0E7QUFLQTtBQ0NBO0FEQ0E7QUNGQTtBQUNBO0FBSUE7QURBQTtBQ0FBO0FBQ0E7QUFBQTtBQUNBO0FBQ0E7QUFDQTtBQURBO0FBQ0E7QUFHQTtBQUNBO0FBQ0E7QUFDQTtBQUZBO0FBQ0E7QUFJQTtBQUNBO0FBQ0E7QUFEQTtBQUNBO0FBR0E7QUFDQTtBQWxCQTtBQW9CQSIsInNvdXJjZVJvb3QiOiIifQ==");

/***/ }

})