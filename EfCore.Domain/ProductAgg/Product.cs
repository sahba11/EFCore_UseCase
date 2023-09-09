using EfCore.Domain.ProductCategoryAgg;
using System;

namespace EfCore.Domain.ProductAgg
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreationDate { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        public Product(string name, double unitPrice, int categoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            CategoryId = categoryId;
            CreationDate = DateTime.Now;
        }

        public void Edit(string name, double unitPrice, int categoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            CategoryId = categoryId;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
