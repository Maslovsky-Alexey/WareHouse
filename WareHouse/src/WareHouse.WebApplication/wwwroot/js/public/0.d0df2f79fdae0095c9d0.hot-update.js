webpackHotUpdate(0,{

/***/ 224:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\nexports.default = items;\n\nvar _items = __webpack_require__(122);\n\nvar _pollingEventManager = __webpack_require__(433);\n\nvar initialState = {\n  items: [],\n  errorMessage: null\n};\n\nfunction items() {\n  var state = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : initialState;\n  var action = arguments[1];\n\n  switch (action.type) {\n    case _items.GET_ITEMS_REQUEST:\n      return Object.assign({}, state, {\n        errorMessage: null\n      });\n\n    case _items.GET_ITEMS_SUCCESS:\n      return Object.assign({}, state, {\n        items: action.payload,\n        errorMessage: null\n      });\n\n    case _items.GET_ITEMS_FAILED:\n      return Object.assign({}, state, {\n        errorMessage: action.payload.errorMessage\n      });\n\n    case _pollingEventManager.CHANGE_OR_ADD_ITEM:\n      var newState = Object.assign({}, state);\n      for (var i = 0; i < newState.items.length; i++) {\n        if (newState.items[i].id == action.payload.id) {}\n      }\n\n      return;\n\n    default:\n      return state;\n  }\n}//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMjI0LmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL3JlZHVjZXJzL2l0ZW1zL2l0ZW1zLmpzP2RjN2IiLCJ3ZWJwYWNrOi8vLz9kNDFkIl0sInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7XHJcbiAgR0VUX0lURU1TX1JFUVVFU1QsXHJcbiAgR0VUX0lURU1TX1NVQ0NFU1MsXHJcbiAgR0VUX0lURU1TX0ZBSUxFRFxyXG59IGZyb20gJy4uLy4uL2NvbnN0YW50cy9pdGVtcy9pdGVtcydcclxuXHJcbmltcG9ydCB7XHJcbiAgQ0hBTkdFX09SX0FERF9JVEVNLFxyXG59IGZyb20gJy4uLy4uL2NvbnN0YW50cy9wb2xsaW5nRXZlbnRNYW5hZ2VyL3BvbGxpbmdFdmVudE1hbmFnZXInXHJcblxyXG5jb25zdCBpbml0aWFsU3RhdGUgPSB7XHJcbiAgaXRlbXM6IFtdLFxyXG4gIGVycm9yTWVzc2FnZTogbnVsbFxyXG59XHJcblxyXG5leHBvcnQgZGVmYXVsdCBmdW5jdGlvbiBpdGVtcyhzdGF0ZSA9IGluaXRpYWxTdGF0ZSwgYWN0aW9uKSB7XHJcbiAgc3dpdGNoIChhY3Rpb24udHlwZSkge1xyXG4gICBjYXNlIEdFVF9JVEVNU19SRVFVRVNUOlxyXG4gICAgIHJldHVybiBPYmplY3QuYXNzaWduKHt9LCBzdGF0ZSwge1xyXG4gICAgICAgZXJyb3JNZXNzYWdlOiBudWxsXHJcbiAgICAgfSlcclxuXHJcbiAgIGNhc2UgR0VUX0lURU1TX1NVQ0NFU1M6XHJcbiAgICAgcmV0dXJuIE9iamVjdC5hc3NpZ24oe30sIHN0YXRlLCB7XHJcbiAgICAgICBpdGVtczogYWN0aW9uLnBheWxvYWQsXHJcbiAgICAgICBlcnJvck1lc3NhZ2U6IG51bGxcclxuICAgICB9KVxyXG5cclxuICAgIGNhc2UgR0VUX0lURU1TX0ZBSUxFRDpcclxuICAgICAgcmV0dXJuIE9iamVjdC5hc3NpZ24oe30sIHN0YXRlLCB7XHJcbiAgICAgICAgZXJyb3JNZXNzYWdlOiBhY3Rpb24ucGF5bG9hZC5lcnJvck1lc3NhZ2VcclxuICAgICAgfSlcclxuXHJcbiAgICBjYXNlIENIQU5HRV9PUl9BRERfSVRFTTpcclxuICAgICAgbGV0IG5ld1N0YXRlID0gT2JqZWN0LmFzc2lnbih7fSwgc3RhdGUpO1xyXG4gICAgICBmb3IgKGxldCBpID0gMDsgaSA8IG5ld1N0YXRlLml0ZW1zLmxlbmd0aDsgaSsrKXtcclxuICAgICAgICBpZiAobmV3U3RhdGUuaXRlbXNbaV0uaWQgPT0gYWN0aW9uLnBheWxvYWQuaWQpe1xyXG4gICAgICAgICAgXHJcbiAgICAgICAgfVxyXG4gICAgICB9XHJcblxyXG4gICAgICByZXR1cm5cclxuXHJcbiAgICAgZGVmYXVsdDpcclxuICAgICAgIHJldHVybiBzdGF0ZTtcclxuICAgfVxyXG59XHJcblxuXG5cbi8qKiBXRUJQQUNLIEZPT1RFUiAqKlxuICoqIC4vc3JjL3JlZHVjZXJzL2l0ZW1zL2l0ZW1zLmpzXG4gKiovIiwidW5kZWZpbmVkXG5cblxuLyoqIFdFQlBBQ0sgRk9PVEVSICoqXG4gKiogXG4gKiovIl0sIm1hcHBpbmdzIjoiOzs7OztBQWVBO0FBQ0E7QUFoQkE7QUFDQTtBQUtBO0FBQ0E7QUFHQTtBQ0NBO0FEQ0E7QUNGQTtBQUNBO0FBSUE7QURBQTtBQ0FBO0FBQ0E7QUFBQTtBQUNBO0FBQ0E7QUFDQTtBQURBO0FBQ0E7QUFHQTtBQUNBO0FBQ0E7QUFDQTtBQUZBO0FBQ0E7QUFJQTtBQUNBO0FBQ0E7QUFEQTtBQUNBO0FBR0E7QUFDQTtBQUNBO0FBQ0E7QUFHQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUE1QkE7QUE4QkEiLCJzb3VyY2VSb290IjoiIn0=");

/***/ }

})