using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmartClient.Models
{
    public class Productdto
    {
        [Required]
        public int ProductId { get; set; }

        [MaxLength(100)]
        public string ProductName { get; set; }
        public string Make { get; set; }

        public int Price { get; set; }

        
        public int CatId { get; set; }

        public string ImagePath { get; set; }
    }
}
