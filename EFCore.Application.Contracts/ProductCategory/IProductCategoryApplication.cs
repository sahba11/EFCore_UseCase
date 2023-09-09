using System.Collections.Generic;

namespace EFCore.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        void Create(CreateProductCategory command);
        void Edit(EditProductCategory command);
        EditProductCategory GetDetails(int id);
        List<ProductCategoryViewModel> Search(string name);
        List<ProductCategoryViewModel> GetAll();
    }
}
