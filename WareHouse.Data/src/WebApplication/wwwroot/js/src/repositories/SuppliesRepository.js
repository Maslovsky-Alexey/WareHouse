import ServerMediator from './ServerMediator'

export default class SuppliesRepository extends ServerMediator{
  getSupplies(success) {
      super.sendRequest("api/supplies/", "get", null,
          (data) => success(JSON.parse(data)));
  };

  getProviderSupplies(providerName, success) {
      super.sendRequest("api/supplies/" + providerName, "get", null,
          (data) => success(JSON.parse(data)));
  };
};
