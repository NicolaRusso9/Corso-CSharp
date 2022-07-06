using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CorsoCSharp.EFCore.AutoGenModels;

namespace PraticalApps.Pages
{
    public class SuppliersModel : PageModel
    {
        public IEnumerable<string>? Suppliers { get; set; }
        private NorthwindContext db;

        public SuppliersModel(NorthwindContext injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "northwind b2b -Suppliers";

        }
    }
}
