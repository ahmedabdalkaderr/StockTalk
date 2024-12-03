using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTalk.Entities.DTOs.CommentDto
{
    public class UpdateCommentDto
    {
        public string? Title { get; set; }

        public string? Content { get; set; }
    }
}
