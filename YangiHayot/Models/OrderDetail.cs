﻿using System.ComponentModel.DataAnnotations;

namespace YangiHayot.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
