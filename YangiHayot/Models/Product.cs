using System.ComponentModel.DataAnnotations;

namespace YangiHayot.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }
        public string Photo { get; set; }
        public int Quantity { get; set; }
    }
}
