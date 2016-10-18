var Dispatcher = require('../dispatcher/dispatcher.js').Dispatcher;
var ItemRepository = require('../repositories/itemrepository.js').ItemRepository;

var items = [];
var itemRepository = new ItemRepository();
var onChangeListeners = [];

itemRepository.getItems((data) => {
    items = data;
    onChangeListeners.forEach((callback) => callback(items));
});

function addItem(item) {
    itemRepository.addItem(item, function () {
        itemRepository.getItems(function (data) {
            items = data;

            onChangeListeners.forEach((callback) => callback(items));
        });
    });
};


var ItemStore = {
    addOnChangeListener: function(callback){
        onChangeListeners.push(callback);
    },

    getItems: function () {
        return items;
    }
};

Dispatcher.register(function (payload) {
    if (payload.name == 'add-item') {
        addItem(payload.data);
    }    
});


exports.ItemStore = ItemStore;