using System.ComponentModel.DataAnnotations;
using StockTalk.Entities.Models;

namespace StockTalk.Entities.DTOs.CommentDto
{
    public class CreateCommentDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title can't be longer than 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(1000, ErrorMessage = "Content can't be longer than 1000 characters.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "StockId is required.")]
        public int StockId { get; set; }

        [Required(ErrorMessage = "Creation date is required.")]
        public DateTime Created { get; set; }
    }
}
