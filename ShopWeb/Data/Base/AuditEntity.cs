namespace ShopWeb.Data.Base
{
    public abstract class AuditEntity
    {
        public AuditEntity()
        {
            Creation_Date = DateTime.Now;
            Deleted = false;
        }

        public int Creation_User { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime? Modify_Date { get; set; }
        public int? Modify_User { get; set; }
        public int? Delete_User { get; set; }
        public DateTime? Delete_Date { get; set; }
        public bool Deleted { get; set; }
    }
}
