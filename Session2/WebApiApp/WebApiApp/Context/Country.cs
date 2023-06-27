using System.ComponentModel.DataAnnotations;

namespace WebApiApp.Context
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public List<Hotel> hotels { get; set;}
    }
}
