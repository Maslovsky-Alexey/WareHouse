var React = require('react');
var ReactDom = require('react-dom');

var FormOperations = require('./form/formoperations.jsx');
var Dispatcher = require('../../dispatcher/dispatcher.js').Dispatcher;
var ClientStore = require('../../stores/clientstore.js').ClientStore;
var ProviderStore = require('../../stores/providerstore.js').ProviderStore;
var List = require('./list/list.jsx');

var OperationsView = React.createClass({
    listItem: '',

    supplymode: true,

    componentDidMount: function () {
        ClientStore.addOnChangeListener(this.onClientsGeted);
        ProviderStore.addOnChangeListener(this.onProvidersGeted);
    },

    getInitialState: function(){
        var clients = ClientStore.getClients(this.onClientsGeted).map((item) => item.name);
        var providers = ProviderStore.getProviders(this.onProvidersGeted).map((item) => item.name);

        return { clients: clients, providers: providers };
    },

    SelectedListItem: function(item){
        this.listItem = item;
        this.forceUpdate();
    },

    onProvidersGeted: function (data) {
        this.setState({ clients: this.state.clients, providers: data.map((item) => item.name) });
    },

    onClientsGeted: function (data) {
        this.setState({ clients: data.map((item) => item.name), providers: this.state.providers });
    },

    modeChange: function(isSupply){
        this.supplymode = isSupply;
        this.forceUpdate();
    },

    providerAdded: function (value) {
        Dispatcher.dispatch({
            name: 'add-provider',
            data: { name: value }
        });
    },

    clientAdded: function (value) {
        Dispatcher.dispatch({
            name: 'add-client',
            data: { name: value }
        });
    },

    render: function () {

        return (
            <div className="row">
                <div className="col-xs-3">
                    <List.List title="Providers" side="left" active={this.supplymode} changevalue={this.SelectedListItem} items={this.state.providers} onadded={this.providerAdded}/>
                </div>
                <div className="col-xs-6">
                    <FormOperations.FormOperations actor={this.listItem} changeMode={this.modeChange}/>
                </div>
                <div className="col-xs-3">
                    <List.List title="Clients" side="right" active={!this.supplymode} changevalue={this.selectedlistitem} items={this.state.clients} onadded={this.clientAdded}/>
                </div>                            
            </div>
        );
    }
});

exports.OperationsView = OperationsView;