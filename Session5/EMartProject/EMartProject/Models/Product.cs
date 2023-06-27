using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMartProject.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [MaxLength(100)]
        public string ProductName { get; set; }
        public string Make { get; set; }

        public int Price { get; set; }

        [ForeignKey("category")]
        public int CatId { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public Category category { get; set; }
    }
}
