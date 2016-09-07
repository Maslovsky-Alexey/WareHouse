using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Data.EF.Repository;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public abstract class BaseService<T> : IService<T> where T : BaseModel
    {
        private BaseRepository<T> repository;

        public BaseService(BaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await repository.GetAll();          
        }

        public async Task Add(T item)
        {
            await repository.Add(item);
        }

        public async Task Remove(T item)
        {
            await repository.Remove(item);
        }

        public async Task<T> GetItem(int id)
        {
            return await repository.GetItem(id);
        }

        public async Task<int> Count()
        {
            return await repository.Count();
        }
    }
}
