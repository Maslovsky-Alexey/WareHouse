webpackHotUpdate(0,{

/***/ 121:
/***/ function(module, exports, __webpack_require__) {

	eval("'use strict';\n\nObject.defineProperty(exports, \"__esModule\", {\n    value: true\n});\n\nvar _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if (\"value\" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();\n\nvar _react = __webpack_require__(4);\n\nvar _react2 = _interopRequireDefault(_react);\n\n__webpack_require__(428);\n\nfunction _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }\n\nfunction _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError(\"Cannot call a class as a function\"); } }\n\nfunction _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError(\"this hasn't been initialised - super() hasn't been called\"); } return call && (typeof call === \"object\" || typeof call === \"function\") ? call : self; }\n\nfunction _inherits(subClass, superClass) { if (typeof superClass !== \"function\" && superClass !== null) { throw new TypeError(\"Super expression must either be null or a function, not \" + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }\n\nvar Items = function (_Component) {\n    _inherits(Items, _Component);\n\n    function Items() {\n        _classCallCheck(this, Items);\n\n        return _possibleConstructorReturn(this, (Items.__proto__ || Object.getPrototypeOf(Items)).apply(this, arguments));\n    }\n\n    _createClass(Items, [{\n        key: 'componentWillMount',\n        value: function componentWillMount() {}\n    }, {\n        key: 'render',\n        value: function render() {\n            var data = this.props.items;\n            var newsTemplate = null;\n\n            if (data != null) {\n                var _newsTemplate = data.map(function (item, index) {\n                    return _react2.default.createElement(\n                        'div',\n                        { className: 'col-sm-4 col-lg-4 col-md-4', key: index },\n                        _react2.default.createElement(\n                            'div',\n                            { className: 'thumbnail' },\n                            item.base64,\n                            _react2.default.createElement('img', { src: item.base64 ? item.base64 : \"http://placehold.it/320x150\", alt: '' }),\n                            _react2.default.createElement(\n                                'div',\n                                { className: 'caption' },\n                                _react2.default.createElement(\n                                    'h4',\n                                    { className: 'pull-right' },\n                                    'count: ',\n                                    item.count\n                                ),\n                                _react2.default.createElement(\n                                    'h4',\n                                    null,\n                                    _react2.default.createElement(\n                                        'a',\n                                        { href: item.link ? item.link : \"#\" },\n                                        item.name ? item.name : \"Noname\"\n                                    )\n                                ),\n                                _react2.default.createElement(\n                                    'p',\n                                    null,\n                                    item.description\n                                )\n                            )\n                        )\n                    );\n                });\n\n                return _react2.default.createElement(\n                    'div',\n                    null,\n                    _newsTemplate\n                );\n            }\n        }\n    }]);\n\n    return Items;\n}(_react.Component);\n\nexports.default = Items;//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiMTIxLmpzIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vLy4vc3JjL2NvbXBvbmVudHMvd2FyZWhvdXNlSXRlbXMvcGFnZUl0ZW1zLmpzPzNjNGIiLCJ3ZWJwYWNrOi8vLz9kNDFkIl0sInNvdXJjZXNDb250ZW50IjpbImltcG9ydCBSZWFjdCwgeyBQcm9wVHlwZXMsIENvbXBvbmVudCB9IGZyb20gJ3JlYWN0J1xyXG5pbXBvcnQgJy4uLy4uL3N0eWxlL2NvbXBvbmVudHMvd2FyZWhvdXNlSXRlbXMvcGFnZUl0ZW1zLmNzcydcclxuXHJcblxyXG5leHBvcnQgZGVmYXVsdCBjbGFzcyBJdGVtcyBleHRlbmRzIENvbXBvbmVudCB7XHJcbiAgY29tcG9uZW50V2lsbE1vdW50KCl7XHJcblxyXG4gIH1cclxuXHJcbiAgcmVuZGVyKCkge1xyXG4gICAgbGV0IGRhdGEgPSB0aGlzLnByb3BzLml0ZW1zXHJcbiAgICBsZXQgbmV3c1RlbXBsYXRlID0gbnVsbFxyXG5cclxuICAgIGlmIChkYXRhICE9IG51bGwpe1xyXG4gICAgICBsZXQgbmV3c1RlbXBsYXRlID0gZGF0YS5tYXAoZnVuY3Rpb24oaXRlbSwgaW5kZXgpIHtcclxuICAgICAgICAgIHJldHVybiAoXHJcbiAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9XCJjb2wtc20tNCBjb2wtbGctNCBjb2wtbWQtNFwiIGtleT17aW5kZXggfT5cclxuICAgICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9XCJ0aHVtYm5haWxcIj5cclxuICAgICAgICAgICAgICAgICAgICAgIHtpdGVtLmJhc2U2NH1cclxuICAgICAgICAgICAgICAgICAgICAgIDxpbWcgc3JjPXtpdGVtLmJhc2U2NCA/IGl0ZW0uYmFzZTY0IDogXCJodHRwOi8vcGxhY2Vob2xkLml0LzMyMHgxNTBcIn0gYWx0PVwiXCIvPlxyXG4gICAgICAgICAgICAgICAgICAgICAgPGRpdiBjbGFzc05hbWU9XCJjYXB0aW9uXCI+XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgPGg0IGNsYXNzTmFtZT1cInB1bGwtcmlnaHRcIj5jb3VudDoge2l0ZW0uY291bnR9PC9oND5cclxuICAgICAgICAgICAgICAgICAgICAgICAgICA8aDQ+XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDxhIGhyZWY9e2l0ZW0ubGluayA/IGl0ZW0ubGluayA6IFwiI1wiIH0+e2l0ZW0ubmFtZSA/IGl0ZW0ubmFtZSA6IFwiTm9uYW1lXCJ9PC9hPlxyXG4gICAgICAgICAgICAgICAgICAgICAgICAgIDwvaDQ+XHJcbiAgICAgICAgICAgICAgICAgICAgICAgICAgPHA+e2l0ZW0uZGVzY3JpcHRpb259PC9wPlxyXG4gICAgICAgICAgICAgICAgICAgICAgPC9kaXY+XHJcbiAgICAgICAgICAgICAgICAgIDwvZGl2PlxyXG4gICAgICAgICAgICAgIDwvZGl2PlxyXG4gICAgICAgICAgKTtcclxuICAgICAgfSk7XHJcblxyXG4gICAgICByZXR1cm4gPGRpdj57bmV3c1RlbXBsYXRlfTwvZGl2PlxyXG4gICAgfVxyXG5cclxuICB9XHJcbn1cclxuXG5cblxuLyoqIFdFQlBBQ0sgRk9PVEVSICoqXG4gKiogLi9zcmMvY29tcG9uZW50cy93YXJlaG91c2VJdGVtcy9wYWdlSXRlbXMuanNcbiAqKi8iLCJ1bmRlZmluZWRcblxuXG4vKiogV0VCUEFDSyBGT09URVIgKipcbiAqKiBcbiAqKi8iXSwibWFwcGluZ3MiOiI7Ozs7Ozs7O0FBQUE7QUFDQTs7O0FBQUE7QUFDQTs7Ozs7Ozs7O0FBRUE7Ozs7Ozs7Ozs7O0FBQ0E7OztBQUlBO0FBQ0E7QUNDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFBQTtBQUNBO0FBQUE7QUFBQTtBQUNBO0FBQ0E7QUFDQTtBQUFBO0FBQUE7QUFDQTtBQUFBO0FBQUE7QUFBQTtBQUFBO0FBQUE7QUFDQTtBQUFBO0FBQUE7QUFDQTtBQUFBO0FBQUE7QUFBQTtBQUFBO0FBREE7QUFHQTtBQUFBO0FBQUE7QUFBQTtBQUFBO0FBTEE7QUFIQTtBQURBO0FBY0E7QUFDQTtBQUNBO0FBQUE7QUFBQTtBQUFBO0FBQUE7QUFDQTtBQUVBOzs7Ozs7QUEvQkEiLCJzb3VyY2VSb290IjoiIn0=");

/***/ }

})