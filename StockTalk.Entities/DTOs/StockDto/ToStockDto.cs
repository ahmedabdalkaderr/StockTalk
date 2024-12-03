
namespace StockTalk.Entities.DTOs.StockDto
{
    public class ToStockDto
    {
        public int Id { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; }

    }
}
