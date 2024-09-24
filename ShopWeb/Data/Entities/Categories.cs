using ShopWeb.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWeb.Data.Entities
{
    [Table("Categories")]
    public sealed class Categories : AuditEntity
    {
        [Key] 
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

    }
}
