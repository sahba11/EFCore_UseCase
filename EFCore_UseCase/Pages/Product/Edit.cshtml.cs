using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCore_UseCase.Pages.Product
{
    public class EditModel : PageModel
    {
        public EditProduct Command;
        public SelectList ProductCategories;
        private readonly IProductApplication productApplication;
        private readonly IProductCategoryApplication productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication, IProductApplication productApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
            this.productApplication = productApplication;
        }

        public void OnGet(int id)
        {
            ProductCategories = new SelectList(productCategoryApplication.GetAll(), "Id", "Name");
            Command = productApplication.GetDetails(id);
        }

        public RedirectToPageResult OnPost(EditProduct command)
        {
            productApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
