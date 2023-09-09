using EfCore.Domain.ProductAgg;
using EFCore.Application.Contracts.Product;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.Infrastructure.EFCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EfContext efContext;

        public ProductRepository(EfContext efContext)
        {
            this.efContext = efContext;
        }

        public void Attach(Product product)
        {
            efContext.Attach(product);
        }

        public void Create(Product product)
        {
            efContext.Products.Add(product);
        }

        public bool Exists(string name, int categoryId)
        {
            return efContext.Products.Any(x => x.Name == name && x.CategoryId == categoryId);
        }

        public Product Get(int id)
        {
            return efContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public EditProduct GetDetails(int id)
        {
            return efContext.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                CategoryId = x.CategoryId
            }).FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            efContext.SaveChanges();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = efContext.Products
                .Include(x => x.Category)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    UnitPrice = x.UnitPrice,
                    IsRemoved = x.IsRemoved,
                    CreationDate = x.CreationDate.ToString(),
                    Category = x.Category.Name
                });

            if (searchModel.IsRemoved == true)
                query = query.Where(x => x.IsRemoved == true);

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query
                .OrderByDescending(x => x.Id)
                .AsNoTracking()
                .ToList();
        }
    }
}
