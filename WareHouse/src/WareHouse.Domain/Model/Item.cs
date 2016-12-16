namespace WareHouse.Domain.Model
{
    public class Item : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Base64 { get; set; }
    }
}