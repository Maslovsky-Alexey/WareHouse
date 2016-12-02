using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Service.ElasticSearchProviders
{
    public interface IElasticSearchProvider<T>
    {
        IEnumerable<T> QueryString(string term);

        void AddUpdateEntity(T skill);

        void UpdateSkill(T skill);

        void DeleteSkill(long deleteId);
    }
}
