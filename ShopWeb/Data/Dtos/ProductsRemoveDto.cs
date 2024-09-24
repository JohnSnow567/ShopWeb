namespace ShopWeb.Data.Dtos
{
    public record ProductsRemoveDto
    {
        public int ProductID { get; set; }
        public int UserDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
