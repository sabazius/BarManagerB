namespace BarManager.Models.Requests
{
    public class ProductsUpdateRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
