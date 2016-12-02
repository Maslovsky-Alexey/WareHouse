using WareHouse.Data.Model;

namespace WareHouse.Domain.Model
{
    public class ItemStatus : BaseModel
    {
        public string Name { get; set; }

        public virtual Status Status { get; set; }
    }
}