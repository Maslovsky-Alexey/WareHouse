using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WareHouse.Domain.Service.ModelsMapper
{
    //TODO: Нужно сделать обобщенную реазилацию сразу для всех, отдельно только создать конфигурацию маппинга
    public class ClientMapper
    {
        private IMapper mapperToEF;
        private IMapper mapperToService;

        public ClientMapper()
        {
            var configEF = new MapperConfiguration(cfg => cfg.CreateMap<Domain.Model.Client, Data.Model.Client>());
            mapperToEF = configEF.CreateMapper();

            var configserv = new MapperConfiguration(cfg => cfg.CreateMap<Data.Model.Client, Domain.Model.Client>());
            mapperToService = configserv.CreateMapper();
        }

        public Domain.Model.Client MapService(Data.Model.Client source)
        {
            return mapperToService.Map<Domain.Model.Client>(source);
        }

        public Data.Model.Client MapEF(Domain.Model.Client source)
        {
            return mapperToEF.Map<Data.Model.Client>(source);
        }
    }
}
