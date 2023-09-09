using EFCore.Application.Contracts.Product;
using System.Collections.Generic;

namespace EfCore.Domain.ProductAgg
{
    public interface IProductRepository
    {
        Product Get(int id);
        EditProduct GetDetails(int id);
        void Create(Product product);
        void SaveChanges();
        void Attach(Product product);
        bool Exists(string name, int categoryId);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
