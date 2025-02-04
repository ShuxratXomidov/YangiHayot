using System.ComponentModel.DataAnnotations;
using YangiHayot.Enums;

namespace YangiHayot.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } // tipini doubledan decimale ga uzgartirdim
        public ProductSizeEnum Size { get; set; }
        public string Photo { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
