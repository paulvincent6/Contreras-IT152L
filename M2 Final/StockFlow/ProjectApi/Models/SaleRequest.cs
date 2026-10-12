using System.Collections.Generic;

namespace ProjectApi.Models
{
    public class SaleRequest
    {
        public List<SaleItemRequest> Items { get; set; } = new();
    }

    public class SaleItemRequest
    {
        public string ItemCode { get; set; } = "";

        public int Quantity { get; set; }
    }
}
