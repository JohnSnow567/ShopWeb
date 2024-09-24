namespace ShopWeb.Data.Dtos
{
    public record CustomersRemoveDto
    {
        public int CustID { get; set; }
        public int UserDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
