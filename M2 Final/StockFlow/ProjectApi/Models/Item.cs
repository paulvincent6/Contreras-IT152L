namespace ProjectApi.Models
{
    public class Item
    {
        public string Code { get; set; } = "";

        public string Name { get; set; } = "";

        public string Brand { get; set; } = "";

        public string Category { get; set; } = "";

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int ReorderLevel { get; set; } = 5;
    }
}
