using WareHouse.Domain.ServiceInterfaces.Safe;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class OperationProxyService : ISafeOperationService
    {
        private ISafeOperationService safeOperationService;


        public OperationProxyService(ISafeOperationService safeOperationService)
        {
            this.safeOperationService = safeOperationService;
        }
    }
}
