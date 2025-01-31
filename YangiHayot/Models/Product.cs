﻿using System.ComponentModel.DataAnnotations;
using YangiHayot.Enums;

namespace YangiHayot.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductSizeEnum Size { get; set; }
        public string Photo { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
