using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;
using WareHouse.LogHelper;

namespace WareHouse.Data.EF.Repository
{
    public class WarehouseItemSQLRepository : BaseRepository<WarehouseItem>, IWarehouseItemRepository
    {
        private SQLHelper.SQLHelper sql;

        public WarehouseItemSQLRepository(WareHouseDbContext context) : base(context)
        {
            Initialize();
        }

        public WarehouseItemSQLRepository(WareHouseDbContext context, ILog log) : base(context, log)
        {
            Initialize();
        }

        private void Initialize()
        {
            sql = new SQLHelper.SQLHelper(context.Database.GetDbConnection().ConnectionString);
        }

        public override async Task<OperationStatus> Add(WarehouseItem item)
        {
            try
            {
                await sql.ExecSQLAsync("exec WarehouseItemAdd @itemId, @count", new SqlParameter("@itemId", item.Item.Id), new SqlParameter("@count", item.Count));
                return OperationStatus.Added;
            }
            catch(Exception e)
            {
                log?.Log(e.Message + '\n' + e.InnerException);
                return OperationStatus.Error;
            }
        }

        public override async Task<int> Count()
        {
            try
            {        
                return await sql.Count("GetWarehouseItemsCount");
            }
            catch (Exception e)
            {
                log?.Log(e.Message + '\n' + e.InnerException);
                return -1;
            }
        }

        public override async Task<OperationStatus> Remove(WarehouseItem item)
        {
            try
            {
                await sql.ExecSQLAsync("exec RemoveWarehouseItemById @itemId", new SqlParameter("@itemId", item.Item.Id));
                return OperationStatus.Added;
            }
            catch (Exception e)
            {
                log?.Log(e.Message + '\n' + e.InnerException);
                return OperationStatus.Error;
            }
        }

        public async Task<WarehouseItem> GetItemByName(string name, bool ignoreCase)
        {
            try
            {
                var item = await sql.GetFirstItemAsync<WarehouseItem>("exec GetItemByName @name", new SqlParameter("@name", name));
                item.Item = await GetItemById(item.ItemId);

                return item;
            }
            catch (Exception e)
            {
                log?.Log(e.Message + '\n' + e.InnerException);
                return null;
            }
        }

        public override async Task<IEnumerable<WarehouseItem>> GetAll()
        {
            try
            {
                var items = await sql.GetItemsAsync<WarehouseItem>("exec GetAllWarehouseItems");

                foreach (var item in items)
                {
                    item.Item = await GetItemById(item.ItemId);
                }

                return items;
            }
            catch (Exception e)
            {
                log?.Log(e.Message + '\n' + e.InnerException);
                return null;
            }
        }

        public override async Task<IEnumerable<WarehouseItem>> GetAllWithFilter(
            Expression<Func<WarehouseItem, bool>> filter)
        {
            return (await GetAll()).AsQueryable().Where(filter);
        }

        public async Task<bool> UpdateCount(int warehouseItemId, int deltaCount)
        {
            try
            {
                var item = await GetItem(warehouseItemId);

                if (item == null)
                    return false;

                item.Count += deltaCount;

                await sql.ExecSQLAsync("exec UpdateCountWarehouseItem @itemId, @count", new SqlParameter("@itemId", item.Id), new SqlParameter("@count", item.Count));
                return true;
            }
            catch (Exception e)
            {
                log?.Log(e.Message + '\n' + e.InnerException);
                return false;
            }
        }

        public override async Task<WarehouseItem> GetItem(int id)
        {
            try
            {
                var item = await sql.GetFirstItemAsync<WarehouseItem>("exec GetWarehouseItemById @id", new SqlParameter("@id", id));
                item.Item = await GetItemById(item.ItemId);

                return item;
            }
            catch (Exception e)
            {
                log?.Log(e.Message + '\n' + e.InnerException);
                return null;
            }
        }

        private async Task<Item> GetItemById(int id)
        {
            return await sql.GetFirstItemAsync<Item>("exec GetItemById @id", new SqlParameter("@id", id));
        }
    }
}
