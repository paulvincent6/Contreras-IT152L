namespace StockFlowDesktop
{
    public class StockMovement
    {
        public int MovementId { get; set; }
        public string ItemCode { get; set; } = "";
        public string MovementType { get; set; } = "";
        public int Quantity { get; set; }
        public string? Reason { get; set; }
        public DateTime MovementDate { get; set; }
    }
}
