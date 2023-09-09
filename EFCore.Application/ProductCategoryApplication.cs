using EfCore.Domain.ProductCategoryAgg;
using EFCore.Application.Contracts.ProductCategory;
using System.Collections.Generic;

namespace EFCore.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;        
        }

        public void Create(CreateProductCategory command)
        {
            if (productCategoryRepository.Exists(command.Name))
                return;

            var productCategory = new ProductCategory(command.Name);
            productCategoryRepository.Create(productCategory);
            productCategoryRepository.SaveChanges();
        }

        public void Edit(EditProductCategory command)
        {
            var productCategory = productCategoryRepository.Get(command.Id);
            if (productCategory == null)
                return;

            productCategory.Edit(command.Name);
            productCategoryRepository.SaveChanges();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return productCategoryRepository.GetAll();
        }

        public EditProductCategory GetDetails(int id)
        {
            return productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            return productCategoryRepository.Search(name);
        }
    }
}
