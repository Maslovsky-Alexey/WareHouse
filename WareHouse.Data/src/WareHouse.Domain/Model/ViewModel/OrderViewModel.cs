namespace WareHouse.Domain.Model.ViewModel
{
    public class OrderViewModel
    {
        public int ItemId { get; set; }

        public int Count { get; set; }

        public int StatusId { get; set; }

        public int ClientId { get; set; }

        public int EmployeeId { get; set; }
    }
}