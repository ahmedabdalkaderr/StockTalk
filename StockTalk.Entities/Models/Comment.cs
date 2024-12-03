using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockTalk.Entities.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Title { get; set; } = string.Empty;

        [Column(TypeName = "varchar(30)")]
        public string Content { get; set; } = string.Empty;
        public int StockId { get; set; }

        public Stock? Stock { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
