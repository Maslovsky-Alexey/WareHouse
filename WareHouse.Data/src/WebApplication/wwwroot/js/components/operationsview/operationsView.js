"use strict";

/// <reference path="form/formoperations.js" />

/// <reference path="../../repositories/clientrepository.js" />
/// <reference path="../../repositories/providerrepository.js" />

var OperartionsView = React.createClass({
    displayName: "OperartionsView",

    listItem: "",
    providerRepos: new ProviderRepository(),
    clientRepos: new ClientRepository(),

    providers: [],
    clients: [],
    supplymode: true,

    getInitialState: function getInitialState() {
        this.clientRepos.getClients(this.onClientsGeted);
        this.providerRepos.getProviders(this.onProvidersGeted);

        return {};
    },

    SelectedListItem: function SelectedListItem(item) {
        this.listItem = item;
        this.forceUpdate();
    },

    onProvidersGeted: function onProvidersGeted(data) {
        this.providers = data.map(function(item) {
            return item.name;
        });

        this.forceUpdate();
    },

    onClientsGeted: function onClientsGeted(data) {
        this.clients = data.map(function(item) {
            return item.name;
        });

        this.forceUpdate();
    },

    modeChange: function modeChange(isSupply) {
        this.supplymode = isSupply;
        this.forceUpdate();
    },

    providerAdded: function providerAdded(value) {
        new ProviderRepository().addProvder({ name: value }, function() {});
    },

    clientAdded: function clientAdded(value) {
        new ClientRepository().addClient({ name: value }, function() {});
    },

    render: function render() {

        return React.createElement(
            "div",
            { className: "row" },
            React.createElement(
                "div",
                { className: "col-xs-3" },
                React.createElement(List,
                {
                    title: "Providers",
                    side: "left",
                    active: this.supplymode,
                    changevalue: this.SelectedListItem,
                    items: this.providers,
                    onadded: this.providerAdded
                })
            ),
            React.createElement(
                "div",
                { className: "col-xs-6" },
                React.createElement(FormOperations, { actor: this.listItem, changeMode: this.modeChange })
            ),
            React.createElement(
                "div",
                { className: "col-xs-3" },
                React.createElement(List,
                {
                    title: "Clients",
                    side: "right",
                    active: !this.supplymode,
                    changevalue: this.selectedlistitem,
                    items: this.clients,
                    onadded: this.clientAdded
                })
            )
        );
    }
});

ReactDOM.render(React.createElement(OperartionsView, null), document.getElementById("root"));