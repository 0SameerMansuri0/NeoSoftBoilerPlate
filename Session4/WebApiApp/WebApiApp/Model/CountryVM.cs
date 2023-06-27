using System.ComponentModel.DataAnnotations;

namespace WebApiApp.Model
{
    public class CountryVM
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
