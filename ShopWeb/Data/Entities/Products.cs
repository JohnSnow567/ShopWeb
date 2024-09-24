using ShopWeb.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace ShopWeb.Data.Entities
{
    [Table("Products")]
    public sealed class Products : AuditEntity
    {

        [Key] 
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }

    }
}
