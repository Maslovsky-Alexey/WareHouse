using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WareHouse.Domain.Service.ModelsMapper
{
    public class ItemMapper
    {
        private IMapper mapperToEF;
        private IMapper mapperToService;

        public ItemMapper()
        {
            var configEF = new MapperConfiguration(cfg => cfg.CreateMap<Domain.Model.Item, Data.Model.Item>());
            mapperToEF = configEF.CreateMapper();

            var configserv = new MapperConfiguration(cfg => cfg.CreateMap<Data.Model.Item, Domain.Model.Item>());
            mapperToService = configserv.CreateMapper();
        }

        public Domain.Model.Item MapService(Data.Model.Item source)
        {
            return mapperToService.Map<Domain.Model.Item>(source);
        }

        public Data.Model.Item MapEF(Domain.Model.Item source)
        {
            return mapperToEF.Map<Data.Model.Item>(source);
        }
    }
}
