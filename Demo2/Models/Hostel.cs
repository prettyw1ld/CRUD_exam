using System.ComponentModel.DataAnnotations;

namespace Demo2.Models
{
    public class Hostel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
