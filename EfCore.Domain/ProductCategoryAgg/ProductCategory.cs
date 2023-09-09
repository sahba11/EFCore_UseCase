using EfCore.Domain.ProductAgg;
using System;
using System.Collections.Generic;

namespace EfCore.Domain.ProductCategoryAgg
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public DateTime CreationDate { get; set; }

        public ProductCategory(string name)
        {
            Name = name;
            CreationDate = DateTime.Now;
            Products = new List<Product>();
        }

        public void Edit(string name)
        {
            Name = name;
        }
    }
}