using System.Collections.Generic;

namespace EFCore.Application.Contracts.Product
{
    public interface IProductApplication
    {
        void Create(CreateProduct command);
        void Edit(EditProduct command);
        void Remove(int id);
        void Restore(int id);
        EditProduct GetDetails(int id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
