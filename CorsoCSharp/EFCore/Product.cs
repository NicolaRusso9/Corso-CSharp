using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorsoCSharp.EFCore
{
    internal class Product
    {
        public int ProductId { get;set; }

        [Required]
        [StringLength(40)]
        public string? ProductName { get; set; } = null;

        [Column("UnitPrice", TypeName="money")]
        public decimal? Cost { get; set; }      // property name != column name, we have mapped name in decorator

        [Column("UnitsInStock")]
        public short? Stock { get; set; }

        public bool Discontinued { get; set; }

        public int? SupplierId { get; set; }

        [StringLength(40)]
        public string? QuantityPerUnit { get; set; } = null;

        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReordelLevel { get; set; }

        // these two define the foreign key relationship to the categories table
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
    }
}
