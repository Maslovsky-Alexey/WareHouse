using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WareHouse.Domain.Service.ModelsMapper
{
    public class ProviderMapper
    {
        private IMapper mapperToEF;
        private IMapper mapperToService;

        public ProviderMapper()
        {
            var configEF = new MapperConfiguration(cfg => cfg.CreateMap<Domain.Model.Provider, Data.Model.Provider>());
            mapperToEF = configEF.CreateMapper();

            var configserv = new MapperConfiguration(cfg => cfg.CreateMap<Data.Model.Provider, Domain.Model.Provider>());
            mapperToService = configserv.CreateMapper();
        }

        public Domain.Model.Provider MapService(Data.Model.Provider source)
        {
            return mapperToService.Map<Domain.Model.Provider>(source);
        }

        public Data.Model.Provider MapEF(Domain.Model.Provider source)
        {
            return mapperToEF.Map<Data.Model.Provider>(source);
        }
    }
}
