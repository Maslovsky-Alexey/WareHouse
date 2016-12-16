webpackHotUpdate(0,{

/***/ 204:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n  value: true\n});\n\nvar _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();\n\nvar _react = __webpack_require__(4);\n\nvar _react2 = _interopRequireDefault(_react);\n\nvar _validationInput = __webpack_require__(120);\n\nvar _validationInput2 = _interopRequireDefault(_validationInput);\n\nvar _Validator = __webpack_require__(131);\n\nvar _Validator2 = _interopRequireDefault(_Validator);\n\nvar _reactBlockUi = __webpack_require__(89);\n\nvar _reactBlockUi2 = _interopRequireDefault(_reactBlockUi);\n\n__webpack_require__(114);\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return call && (typeof call === \"object\" || typeof call === \"function\") ? call : self; }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function, not \" + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }\n\nvar validator = (0, _Validator2.default)();\n\nvar AddItemForm = function (_Component) {\n  _inherits(AddItemForm, _Component);\n\n  function AddItemForm() {\n    var _ref;\n\n    var _temp, _this, _ret;\n\n    _classCallCheck(this, AddItemForm);\n\n    for (var _len = arguments.length, args = Array(_len), _key = 0; _key < _len; _key++) {\n      args[_key] = arguments[_key];\n    }\n\n    return _ret = (_temp = (_this = _possibleConstructorReturn(this, (_ref = AddItemForm.__proto__ || Object.getPrototypeOf(AddItemForm)).call.apply(_ref, [this].concat(args))), _this), _this.name = \"\", _this.desc = \"\", _this.isValidDesc = false, _this.isValidName = false, _this.b64 = \"\", _temp), _possibleConstructorReturn(_this, _ret);\n  }\n\n  _createClass(AddItemForm, [{\n    key: 'toDataUrl',\n    value: function toDataUrl(url, callback) {\n      var xhr = new XMLHttpRequest();\n      xhr.responseType = 'blob';\n      xhr.onload = function () {\n        var reader = new FileReader();\n        reader.onloadend = function () {\n          callback(reader.result);\n        };\n        reader.readAsDataURL(xhr.response);\n      };\n      xhr.open('GET', url);\n      xhr.send();\n    }\n  }, {\n    key: 'componentDidMount',\n    value: function componentDidMount() {\n      var r = this;\n      document.getElementById('file').onchange = function (e) {\n        var reader = new FileReader();\n        reader.onload = function (e) {\n          console.log(e);\n        };\n        reader.readAsDataURL(e.target.files[0]);\n      };\n    }\n  }, {\n    key: 'changeValidName',\n    value: function changeValidName(isValid, text) {\n      this.name = text;\n      this.isValidName = isValid;\n    }\n  }, {\n    key: 'changeValidDesc',\n    value: function changeValidDesc(isValid, text) {\n      this.desc = text;\n      this.isValidDesc = isValid;\n    }\n  }, {\n    key: 'Send',\n    value: function Send() {\n      alert(this.b64);\n\n      if (this.isValidName == false || this.isValidDesc == false || this.b64 == \"\") {\n        return;\n      }\n\n      this.props.send(this.name, this.desc, this.success);\n    }\n  }, {\n    key: 'success',\n    value: function success() {\n      $('#add-input-name').val('');\n      $('#add-input-dis').val('');\n    }\n  }, {\n    key: 'render',\n    value: function render() {\n      return _react2.default.createElement(\n        _reactBlockUi2.default,\n        { blocking: this.props.blocking },\n        _react2.default.createElement(\n          'div',\n          { className: 'container body-content' },\n          _react2.default.createElement(\n            'div',\n            { className: 'row' },\n            _react2.default.createElement(\n              'font',\n              { size: '4', color: '#80b0aa' },\n              'Name'\n            ),\n            _react2.default.createElement(_validationInput2.default, { rule: validator.itemName, changeValid: this.changeValidName.bind(this), id: 'add-input-name' }),\n            _react2.default.createElement(\n              'font',\n              { size: '4', color: '#80b0aa' },\n              'Description'\n            ),\n            _react2.default.createElement(_validationInput2.default, { rule: validator.description, changeValid: this.changeValidDesc.bind(this), id: 'add-input-dis' }),\n            _react2.default.createElement('br', null),\n            _react2.default.createElement('input', { type: 'file', id: 'file' }),\n            _react2.default.createElement(\n              'button',\n              { className: 'btn btn-success', onClick: this.Send.bind(this) },\n              'Add'\n            )\n          )\n        )\n      );\n    }\n  }]);\n\n  return AddItemForm;\n}(_react.Component);\n\nexports.default = AddItemForm;//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMjA0LmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2NvbXBvbmVudHMvYWRkSXRlbS9hZGRJdGVtRm9ybS5qcz9hZDkzIiwid2VicGFjazovLy8/ZDQxZCJdLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgUmVhY3QsIHsgUHJvcFR5cGVzLCBDb21wb25lbnQgfSBmcm9tICdyZWFjdCdcclxuXHJcbmltcG9ydCBWYWxpZGF0aW9uSW5wdXQgZnJvbSAnLi4vb3RoZXJzL3ZhbGlkYXRpb25JbnB1dC92YWxpZGF0aW9uSW5wdXQnO1xyXG5pbXBvcnQgR2V0VmFsaWRhdGlvblJ1bGVzIGZyb20gJy4uLy4uL3ZhbGlkYXRvcnMvVmFsaWRhdG9yJztcclxuXHJcbmltcG9ydCBCbG9ja1VpIGZyb20gJ3JlYWN0LWJsb2NrLXVpJztcclxuaW1wb3J0ICdyZWFjdC1ibG9jay11aS9zdHlsZS5jc3MnXHJcblxyXG5jb25zdCB2YWxpZGF0b3IgPSBHZXRWYWxpZGF0aW9uUnVsZXMoKTtcclxuXHJcbmV4cG9ydCBkZWZhdWx0IGNsYXNzIEFkZEl0ZW1Gb3JtIGV4dGVuZHMgQ29tcG9uZW50IHtcclxuICBuYW1lID0gXCJcIlxyXG4gIGRlc2MgPSBcIlwiXHJcbiAgaXNWYWxpZERlc2MgPSBmYWxzZVxyXG4gIGlzVmFsaWROYW1lID0gZmFsc2VcclxuICBiNjQgPSBcIlwiXHJcblxyXG4gIHRvRGF0YVVybCh1cmwsIGNhbGxiYWNrKSB7XHJcbiAgICB2YXIgeGhyID0gbmV3IFhNTEh0dHBSZXF1ZXN0KCk7XHJcbiAgICB4aHIucmVzcG9uc2VUeXBlID0gJ2Jsb2InO1xyXG4gICAgeGhyLm9ubG9hZCA9IGZ1bmN0aW9uKCkge1xyXG4gICAgICB2YXIgcmVhZGVyID0gbmV3IEZpbGVSZWFkZXIoKTtcclxuICAgICAgcmVhZGVyLm9ubG9hZGVuZCA9IGZ1bmN0aW9uKCkge1xyXG4gICAgICAgIGNhbGxiYWNrKHJlYWRlci5yZXN1bHQpO1xyXG4gICAgICB9XHJcbiAgICAgIHJlYWRlci5yZWFkQXNEYXRhVVJMKHhoci5yZXNwb25zZSk7XHJcbiAgICB9O1xyXG4gICAgeGhyLm9wZW4oJ0dFVCcsIHVybCk7XHJcbiAgICB4aHIuc2VuZCgpO1xyXG4gIH1cclxuXHJcbiAgY29tcG9uZW50RGlkTW91bnQoKXtcclxuICAgIHZhciByID0gdGhpcztcclxuICAgIGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKCdmaWxlJykub25jaGFuZ2UgPSBmdW5jdGlvbiAoZSkge1xyXG4gICAgICBsZXQgcmVhZGVyID0gbmV3IEZpbGVSZWFkZXIoKTtcclxuICAgICAgIHJlYWRlci5vbmxvYWQgPSBmdW5jdGlvbiAoZSkge1xyXG4gICAgICAgICBjb25zb2xlLmxvZyhlKTtcclxuICAgICAgIH1cclxuICAgICAgcmVhZGVyLnJlYWRBc0RhdGFVUkwoZS50YXJnZXQuZmlsZXNbMF0pO1xyXG4gICAgfTtcclxuICB9XHJcblxyXG4gIGNoYW5nZVZhbGlkTmFtZShpc1ZhbGlkLCB0ZXh0KXtcclxuICAgICAgdGhpcy5uYW1lID0gdGV4dDtcclxuICAgICAgdGhpcy5pc1ZhbGlkTmFtZSA9IGlzVmFsaWQ7XHJcbiAgfVxyXG5cclxuICBjaGFuZ2VWYWxpZERlc2MoaXNWYWxpZCwgdGV4dCl7XHJcbiAgICAgIHRoaXMuZGVzYyA9IHRleHQ7XHJcbiAgICAgIHRoaXMuaXNWYWxpZERlc2MgPSBpc1ZhbGlkO1xyXG4gIH1cclxuXHJcbiAgU2VuZCgpe1xyXG4gICAgICBhbGVydCh0aGlzLmI2NCk7XHJcblxyXG4gICAgICBpZiAodGhpcy5pc1ZhbGlkTmFtZSA9PSBmYWxzZSB8fCB0aGlzLmlzVmFsaWREZXNjID09IGZhbHNlIHx8IHRoaXMuYjY0ID09IFwiXCIpe1xyXG4gICAgICAgIHJldHVybjtcclxuICAgICAgfVxyXG5cclxuICAgICAgdGhpcy5wcm9wcy5zZW5kKHRoaXMubmFtZSwgdGhpcy5kZXNjLCB0aGlzLnN1Y2Nlc3MpO1xyXG4gIH1cclxuXHJcbiAgc3VjY2Vzcygpe1xyXG4gICAgJCgnI2FkZC1pbnB1dC1uYW1lJykudmFsKCcnKTtcclxuICAgICQoJyNhZGQtaW5wdXQtZGlzJykudmFsKCcnKTtcclxuICB9XHJcblxyXG4gIHJlbmRlcigpIHtcclxuICAgIHJldHVybiA8QmxvY2tVaSBibG9ja2luZz17dGhpcy5wcm9wcy5ibG9ja2luZ30+XHJcbiAgICAgIDxkaXYgY2xhc3NOYW1lPVwiY29udGFpbmVyIGJvZHktY29udGVudFwiPlxyXG4gICAgICAgIDxkaXYgY2xhc3NOYW1lPVwicm93XCI+XHJcbiAgICAgICAgICAgIDxmb250IHNpemU9JzQnIGNvbG9yPScjODBiMGFhJz5OYW1lPC9mb250PlxyXG4gICAgICAgICAgICA8VmFsaWRhdGlvbklucHV0IHJ1bGU9e3ZhbGlkYXRvci5pdGVtTmFtZX0gY2hhbmdlVmFsaWQ9ezo6dGhpcy5jaGFuZ2VWYWxpZE5hbWV9IGlkPSdhZGQtaW5wdXQtbmFtZScvPlxyXG5cclxuICAgICAgICAgICAgPGZvbnQgc2l6ZT0nNCcgY29sb3I9JyM4MGIwYWEnPkRlc2NyaXB0aW9uPC9mb250PlxyXG4gICAgICAgICAgICA8VmFsaWRhdGlvbklucHV0IHJ1bGU9e3ZhbGlkYXRvci5kZXNjcmlwdGlvbn0gY2hhbmdlVmFsaWQ9ezo6dGhpcy5jaGFuZ2VWYWxpZERlc2N9IGlkPSdhZGQtaW5wdXQtZGlzJy8+XHJcblxyXG4gICAgICAgICAgICA8YnIvPlxyXG4gICAgICAgICAgICA8aW5wdXQgdHlwZT1cImZpbGVcIiBpZD1cImZpbGVcIiAvPlxyXG4gICAgICAgICAgICA8YnV0dG9uIGNsYXNzTmFtZT0nYnRuIGJ0bi1zdWNjZXNzJyBvbkNsaWNrPXs6OnRoaXMuU2VuZH0+QWRkPC9idXR0b24+XHJcbiAgICAgICAgPC9kaXY+XHJcbiAgICA8L2Rpdj5cclxuPC9CbG9ja1VpPlxyXG4gIH1cclxufVxyXG5cblxuXG4vKiogV0VCUEFDSyBGT09URVIgKipcbiAqKiAuL3NyYy9jb21wb25lbnRzL2FkZEl0ZW0vYWRkSXRlbUZvcm0uanNcbiAqKi8iLCJ1bmRlZmluZWRcblxuXG4vKiogV0VCUEFDSyBGT09URVIgKipcbiAqKiBcbiAqKi8iXSwibWFwcGluZ3MiOiI7Ozs7Ozs7O0FBQUE7QUFDQTs7O0FBQ0E7QUFDQTs7O0FBQUE7QUFDQTs7O0FBQ0E7QUFDQTs7O0FBQUE7QUFDQTs7Ozs7Ozs7O0FBQ0E7QUFDQTtBQUNBOzs7Ozs7Ozs7Ozs7OztBQ0NBOzs7OztBQU1BO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOzs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7OztBQUVBO0FBQ0E7QUFDQTtBQUNBOzs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7OztBQUVBO0FBQ0E7QUFDQTtBQUNBOzs7QUFFQTtBQUNBO0FBQUE7QUFBQTtBQUNBO0FBQUE7QUFBQTtBQUNBO0FBQUE7QUFBQTtBQUNBO0FBQUE7QUFBQTtBQUFBO0FBQUE7QUFDQTtBQUVBO0FBQUE7QUFBQTtBQUFBO0FBQUE7QUFDQTtBQUVBO0FBQ0E7QUFDQTtBQUFBO0FBQUE7QUFBQTtBQUFBO0FBVEE7QUFEQTtBQURBO0FBZUE7Ozs7OztBQXpFQSIsInNvdXJjZVJvb3QiOiIifQ==");

/***/ }

})