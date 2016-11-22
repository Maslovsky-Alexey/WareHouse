using System;
using System.Collections.Generic;
using System.Linq;

using ElasticsearchCRUD;
using ElasticsearchCRUD.Model.SearchModel;
using ElasticsearchCRUD.Model.SearchModel.Queries;

using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.Service.ElasticSearchProviders
{
    public class ElasticSearchProvider : IElasticSearchProvider<WarehouseItemViewModel>, IElasticSearchtemProvider
    {

        private const string ConnectionString = "http://localhost:9200/";
        private readonly IElasticsearchMappingResolver elasticSearchMappingResolver = new ElasticsearchMappingResolver();
        private readonly ElasticsearchContext context;

        public ElasticSearchProvider()
        {
            context = new ElasticsearchContext(ConnectionString, elasticSearchMappingResolver);
        }


        public IEnumerable<WarehouseItemViewModel> QueryString(string term)
        {
            if (term == "")
                term = "*";

            var results = context.Search<WarehouseItemViewModel>(BuildQueryStringSearch(term));

            return results?.PayloadResult?.Hits?.HitsResult?.Select(t => t.Source);
        }

        private Search BuildQueryStringSearch(string term)
        {
            var names = "";
            if (term != null)
            {
                names = term.Replace("+", " OR *");
            }

            var search = new ElasticsearchCRUD.Model.SearchModel.Search
            {
                Query = new Query(new QueryStringQuery(names + "*"))
            };

            return search;
        }

        public void AddUpdateEntity(WarehouseItemViewModel data)
        {
            context.AddUpdateDocument(data, data.Id);
            context.SaveChanges();
        }

        public void UpdateSkill(WarehouseItemViewModel data)
        {
            var item = context.GetDocument<WarehouseItemViewModel>(data.Id);
            item.Name = data.Name;
            item.Description = data.Description;
            context.AddUpdateDocument(item, item.Id);
            context.SaveChanges();
        }

        public void DeleteSkill(long deleteId)
        {
            context.DeleteDocument<WarehouseItemViewModel>(deleteId);
            context.SaveChanges();
        }
    }
}
