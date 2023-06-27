using System.ComponentModel.DataAnnotations;

namespace EMartProject.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }

        public  int Quantity { get; set; }

        public decimal Totalprice { get; set; }

        public string UserId { get; set; }
    }
}
