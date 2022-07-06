using CorsoCSharp.EFCore.AutoGenModels;

namespace CoreMVC.Models
{
    public record HomeIndexViewModel(
    
        int VisitorCount,
        IList<Category> Categories,
        IList<Product> Products
    );
    
}
