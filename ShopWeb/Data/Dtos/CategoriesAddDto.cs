namespace ShopWeb.Data.Dtos
{
    public record CategoriesAddDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }


    }
}
