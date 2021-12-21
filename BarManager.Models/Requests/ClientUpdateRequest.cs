namespace BarManager.Models.Requests
{
    public class ClientUpdateRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double MoneySpend { get; set; }

        public int Discount { get; set; }
    }
}
