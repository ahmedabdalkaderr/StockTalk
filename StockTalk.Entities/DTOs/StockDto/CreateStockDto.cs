using System.ComponentModel.DataAnnotations;

namespace StockTalk.Entities.DTOs.StockDto
{
    public class CreateStockDto
    {
        [Required(ErrorMessage = "Company Name is required.")]
        [StringLength(30, ErrorMessage = "Company Name cannot be longer than 100 characters.")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Purchase price must be a positive value.")]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Last dividend must be a positive value.")]
        public decimal LastDiv { get; set; }

        [Required(ErrorMessage = "Industry is required.")]
        [StringLength(30, ErrorMessage = "Industry name cannot be longer than 50 characters.")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "Market Cap must be a positive value.")]
        public long MarketCap { get; set; }
    }
}
