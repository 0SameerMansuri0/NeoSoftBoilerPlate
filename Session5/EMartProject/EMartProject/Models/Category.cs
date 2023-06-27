using System.ComponentModel.DataAnnotations;

namespace EMartProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        List<Product> products { get; set; }
    }
}