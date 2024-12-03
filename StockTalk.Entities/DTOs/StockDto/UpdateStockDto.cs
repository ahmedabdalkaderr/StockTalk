namespace StockTalk.Entities.DTOs.StockDto
{
    public class UpdateStockDto
    {
        public string? CompanyName { get; set; }
        public decimal? Purchase { get; set; }
        public decimal? LastDiv { get; set; }
        public string? Industry { get; set; }
        public long? MarketCap { get; set; }
    }
}
