var browserHistory = require("react-router").browserHistory;

var Redirecter = {
    redirect: function(url) {
        //browserHistory.push(url);
        window.location.href = "/#" + url;
    }
};

exports.Redirecter = Redirecter;