namespace WareHouse.Domain.Model.ViewModel
{
    public class WarehouseItemViewModel : BaseModel
    {
        public string Name { get; set; }

        public int ItemId { get; set; }

        public int Count { get; set; }

        public string Description { get; set; }
    }
}