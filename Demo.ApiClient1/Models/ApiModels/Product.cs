using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.ApiClient1.Models.ApiModels
{
    public class Product
    {
        public int id { get; set; }
        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }

    }
}