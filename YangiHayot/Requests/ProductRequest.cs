using System.ComponentModel.DataAnnotations;
using YangiHayot.Enums;

namespace YangiHayot.Requests
{
    public class ProductRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(1000, 200000)]
        public double Price { get; set; }
        public ProductSizeEnum Size { get; set; }
        //public string Photo { get; set; }
        public int Quantity { get; set; }
    }
}
