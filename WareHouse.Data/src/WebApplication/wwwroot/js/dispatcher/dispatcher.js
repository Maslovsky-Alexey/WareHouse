var callbackList = [];

var Dispatcher = {
    register: function(callback) {
        callbackList.push(callback);
        return callbackList.length - 1;
    },

    dispatch: function(payload) {
        callbackList.forEach((callback) => callback(payload));
    }
};

exports.Dispatcher = Dispatcher;