using System.ComponentModel.DataAnnotations;

namespace YangiHayot.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Price { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
