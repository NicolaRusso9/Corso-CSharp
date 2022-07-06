namespace CoreMVC.Models
{
    public record HomeModelBindingViewModel
    (
        Thing Thing,
        bool HasError,
        IEnumerable<string> ValidationErrors
    );
}
