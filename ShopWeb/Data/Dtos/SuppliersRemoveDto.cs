namespace ShopWeb.Data.Dtos
{
    public record SuppliersRemoveDto
    {
        public int SupplierID { get; set; }
        public int UserDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
