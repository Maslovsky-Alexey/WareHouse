namespace WareHouse.Data.Model
{
    public enum Status
    {
        Processing,
        Success,
        Failure
    }

    public class ItemStatus : BaseModel
    {
        public string Name { get; set; }

        public virtual Status Status { get; set; }
    }
}