using EfCore.Domain.ProductCategoryAgg;
using EFCore.Application.Contracts.ProductCategory;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly EfContext efContext;

        public ProductCategoryRepository(EfContext efContext)
        {
            this.efContext = efContext;
        }

        public void Create(ProductCategory productCategory)
        {
            efContext.ProductCategories.Add(productCategory);
            SaveChanges();
        }

        public bool Exists(string name)
        {
            return efContext.ProductCategories.Any(x => x.Name == name);
        }

        public ProductCategory Get(int id)
        {
            return efContext.ProductCategories.FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return efContext.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public EditProductCategory GetDetails(int id)
        {
            return efContext.ProductCategories.Select(x => new EditProductCategory
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            efContext.SaveChanges();
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            var query = efContext.ProductCategories
                .Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreationDate = x.CreationDate.ToString()
                });

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.Name.Contains(name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
