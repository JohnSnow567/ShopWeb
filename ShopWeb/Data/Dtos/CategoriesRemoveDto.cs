namespace ShopWeb.Data.Dtos
{
    public record CategoriesRemoveDto
    {
        public int CategoryID { get; set; }
        public int UserDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
