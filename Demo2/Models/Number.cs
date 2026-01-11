using System.ComponentModel.DataAnnotations;

namespace Demo2.Models
{
    public class Number
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; } //+7 (9XX) XXX-XX-XX
        public string SerialNumber { get; set; }
        public int IdHostel { get; set; }
    }
}
