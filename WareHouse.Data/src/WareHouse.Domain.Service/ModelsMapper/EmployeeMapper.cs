using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WareHouse.Domain.Service.ModelsMapper
{
    public class EmployeeMapper
    {
        private IMapper mapperToEF;
        private IMapper mapperToService;

        public EmployeeMapper()
        {
            var configEF = new MapperConfiguration(cfg => cfg.CreateMap<Domain.Model.Employee, Data.Model.Employee>());
            mapperToEF = configEF.CreateMapper();

            var configserv = new MapperConfiguration(cfg => cfg.CreateMap<Data.Model.Employee, Domain.Model.Employee>());
            mapperToService = configserv.CreateMapper();
        }

        public Domain.Model.Employee MapService(Data.Model.Employee source)
        {
            return mapperToService.Map<Domain.Model.Employee>(source);
        }

        public Data.Model.Employee MapEF(Domain.Model.Employee source)
        {
            return mapperToEF.Map<Data.Model.Employee>(source);
        }
    }
}
