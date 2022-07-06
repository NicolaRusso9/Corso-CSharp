using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CorsoCSharp.EFCore
{
    internal class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(15)]
        public string? CategoryName { get; set; }

        [Column(TypeName="ntext")]                  // set correct type for db
        public string? Description { get; set; }

        // define a navigation property for related rows
        public virtual ICollection<Product> Products { get;}

        public Category()
        {
            // to enable developers to add products to a category we must initializa the navigation property to an empty collection
            Products = new HashSet<Product>();
        }
    }
}
