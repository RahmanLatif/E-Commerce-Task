using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Task.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
    }
}