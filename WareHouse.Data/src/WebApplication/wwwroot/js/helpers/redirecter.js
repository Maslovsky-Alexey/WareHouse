var browserHistory = require("react-router").browserHistory;

var Redirecter = {
    redirect: function(url) {

        browserHistory.push(url);
    }
};

exports.Redirecter = Redirecter;