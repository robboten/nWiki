using System.ComponentModel.DataAnnotations;

namespace Wiki.App.Entities
{
    public class CreateItem
    {
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string Text { get; set; } = string.Empty;
    }
}