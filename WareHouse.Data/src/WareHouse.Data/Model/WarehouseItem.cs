namespace WareHouse.Data.Model
{
    public class WarehouseItem : BaseModel
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int Count { get; set; }
    }
}