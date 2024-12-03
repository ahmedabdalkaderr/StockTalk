using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockTalk.Entities.Models
{
    public class Stock
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string CompanyName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<StockUser> StockUsers { get; set; } = new List<StockUser>();

    }
}
