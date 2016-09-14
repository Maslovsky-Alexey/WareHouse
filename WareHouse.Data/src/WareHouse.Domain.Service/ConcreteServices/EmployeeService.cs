using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class EmployeeService : BaseService<Domain.Model.Employee, Data.Model.Employee>
    {
        public EmployeeService(BaseRepository<Data.Model.Employee> repository) : base(repository)
        {

        }

        protected override Data.Model.Employee MapToEFModel(Domain.Model.Employee model)
        {
            return new ModelsMapper.EmployeeMapper().MapEF(model);
        }

        protected override Domain.Model.Employee MapToServiceModel(Data.Model.Employee model)
        {
            return new ModelsMapper.EmployeeMapper().MapService(model);
        }
    }
}
