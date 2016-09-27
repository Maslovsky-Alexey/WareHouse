﻿/// <reference path="form/formoperations.js" />

/// <reference path="../../repositories/clientrepository.js" />
/// <reference path="../../repositories/providerrepository.js" />

var OperartionsView = React.createClass({
    listItem: '',
    providerRepos: new CreateProviderRepository(),
    clientRepos: new CreateClientRepository(),

    providers: [],
    clients: [],
    supplymode: true,

    getInitialState: function(){
        this.clientRepos.getClients(this.onClientsGeted);
        this.providerRepos.getProviders(this.onProvidersGeted);

        return {};
    },

    SelectedListItem: function(item){
        this.listItem = item;
        this.forceUpdate();
    },

    onProvidersGeted: function (data) {
        this.providers = data.map(function (item) {
            return item.name;
        });

        this.forceUpdate();
    },

    onClientsGeted: function (data) {
        this.clients = data.map(function (item) {
            return item.name;
        });

        this.forceUpdate();
    },

    modeChange: function(isSupply){
        this.supplymode = isSupply;
        this.forceUpdate();
    },

    providerAdded: function(value){
        new CreateProviderRepository().addProvder({ name: value }, function () { });
    },

    clientAdded: function (value) {
        new CreateClientRepository().addClient({ name: value }, function () { });
    },

    render: function () {

        return (
            <div className="row">
                <div className="col-xs-3">
                    <List title="Providers" side="left" active={this.supplymode} changevalue={this.SelectedListItem} items={this.providers} onadded={this.providerAdded}/>
                </div>
                <div className="col-xs-6">
                    <FormOperations actor={this.listItem} changeMode={this.modeChange}/>
                </div>
                <div className="col-xs-3">
                    <List title="Clients" side="right" active={!this.supplymode} changevalue={this.selectedlistitem} items={this.clients} onadded={this.clientAdded}/>
                </div>                            
            </div>
        );
    }
});

ReactDOM.render(
  <OperartionsView />,
  document.getElementById('root')
);