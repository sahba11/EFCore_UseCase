using EFCore.Application.Contracts.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EFCore_UseCase.Pages.Product
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> Products;
        private readonly IProductApplication productApplication;

        public IndexModel(IProductApplication productApplication)
        {
            this.productApplication = productApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            Products = productApplication.Search(searchModel);
        }
    }
}
