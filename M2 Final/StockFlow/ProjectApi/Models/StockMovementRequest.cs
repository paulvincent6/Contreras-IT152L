namespace ProjectApi.Models
{
    public class StockMovementRequest
    {
        public string ItemCode { get; set; } = "";

        public string MovementType { get; set; } = "";

        public int Quantity { get; set; }

        public string? Reason { get; set; }
    }
}
