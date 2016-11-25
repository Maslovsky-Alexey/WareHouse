import ServerMediator from './ServerMediator'

export default class ActorsRepository extends ServerMediator{
    getClients(success) {
        super.sendRequest("api/clients/",
            "get",
            null,
            function(data) {
                success(JSON.parse(data))
            });
    }

    getProviders(success) {
        super.sendRequest("api/providers/",
            "get",
            null,
            function(data) {
                success(JSON.parse(data))
            });
    }

    addProvder(item, success) {
        super.sendRequest("api/providers", "post", JSON.stringify(item), success)
    }
};
