﻿namespace ShopWeb.Data.Dtos
{
    public record CustomersAddDto
    {
        public int CustID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
    }
}
