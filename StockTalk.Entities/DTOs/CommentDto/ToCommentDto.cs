
using StockTalk.Entities.Models;

namespace StockTalk.Entities.DTOs.CommentDto
{
    public class ToCommentDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string StockCompanyName { get; set; }
        public DateTime Created { get; set; }
    }
}
