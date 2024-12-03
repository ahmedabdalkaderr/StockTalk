﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTalk.Entities.Models
{
    public class StockUser
    {
        public int Id { get; set; } 
        public int StockId { get; set; } 
        public Stock Stock { get; set; } 
        public string UserId { get; set; } 
        public User User { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
