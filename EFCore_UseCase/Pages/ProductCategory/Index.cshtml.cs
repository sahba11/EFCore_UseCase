using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace EFCore_UseCase.Pages.ProductCategory
{
    public class IndexModel : PageModel
    {
        public List<ProductCategoryViewModel> ProdutCategories;
        private readonly IProductCategoryApplication productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(string name)
        {
            ProdutCategories = productCategoryApplication.Search(name);
        }
    }
}
