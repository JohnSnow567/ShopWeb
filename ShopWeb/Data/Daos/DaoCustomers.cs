using ShopWeb.Data.Context;
using ShopWeb.Data.Dtos;
using ShopWeb.Data.Entities;
using ShopWeb.Data.Exceptions;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Data.Daos
{
    public class DaoCustomers : ICustomers
    {
        private readonly ShopDBContext shopDB;
        private readonly ILogger<DaoCustomers> logger;
        public DaoCustomers(ShopDBContext shopDB,
                          ILogger<DaoCustomers> logger)
        {
            this.shopDB = shopDB;
            this.logger = logger;

        }
        public CustomersAddDto GetCustomerById(int customerId)
        {
            CustomersAddDto customerResult = new CustomersAddDto();
            try
            {
                var customer = this.shopDB.Customers.Find(customerId);

                if (customer is null)
                    throw new CustomerException("El cliente no se encuentra registrado.");


                customer.CustID = customer.CustID;
                customer.CompanyName = customer.CompanyName;
                customer.ContactName = customer.ContactName;
                customer.ContactTitle = customer.ContactTitle;
                customer.Address = customer.Address;
                customer.Email = customer.Email;
                customer.City = customer.City;
                customer.Region = customer.Region;
                customer.PostalCode = customer.PostalCode;
                customer.Country = customer.Country;
                customer.Phone = customer.Phone;
                customer.Fax = customer.Fax;
                customer.Creation_User = customer.Creation_User;
                customer.Creation_Date = customer.Creation_Date;
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo al cliente", ex.ToString());
            }
            return customerResult;
        }

        public List<CustomersAddDto> GetCustomers()
        {
            List<CustomersAddDto> customers = new List<CustomersAddDto>();
            try
            {
                customers = (from cst in this.shopDB.Customers
                             where cst.Deleted == false
                             orderby cst.Creation_Date descending
                             select new CustomersAddDto()
                             {
                                 CustID = cst.CustID,
                                 CompanyName = cst.CompanyName,
                                 ContactName = cst.ContactName,
                                 ContactTitle = cst.ContactTitle,
                                 Address = cst.Address,
                                 City = cst.City,
                                 Email = cst.Email,
                                 Region = cst.Region,
                                 PostalCode = cst.PostalCode,
                                 Country = cst.Country,
                                 Phone = cst.Phone,
                                 Fax = cst.Fax,
                                 CreationDate = cst.Creation_Date,
                                 CreationUser = cst.Creation_User,
                             }).ToList();
            }


            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los clientes", ex.ToString());
            }
            return customers;
        }

        public void RemoveCustomer(CustomersRemoveDto removeDto)
        {
            try
            {
                if (removeDto is null)
                    throw new CustomerException("El objeto cliente no puede ser nulo.");


                var customer = this.shopDB.Customers.Find(removeDto.CustID);

                if (customer is null)
                    throw new CustomerException("El cliente no se encuentra registrado.");

                customer.Deleted = true;
                customer.Delete_Date = removeDto.DeletedDate;
                customer.Delete_User = removeDto.UserDeleted;

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error removiendo el cliente", ex.ToString());
            }
        }

        public void SaveCustomer(CustomersAddDto addDto)
        {
            try
            {
                if (addDto is null)
                    throw new CustomerException("El objeto cliente no puede ser nulo.");

                //if (this.shopDB.Customers.Any(spl => spl.CompanyName == addDto.CompanyName))
                //    throw new CustomerException("El objeto cliente no puede ser nulo.");


                Customers customers = new Customers()
                {
                    CompanyName = addDto.CompanyName,
                    ContactName = addDto.ContactName,
                    ContactTitle = addDto.ContactTitle,
                    Address = addDto.Address,
                    City = addDto.City,
                    Email = addDto.Email,
                    Region = addDto.Region,
                    PostalCode = addDto.PostalCode,
                    Country = addDto.Country,
                    Phone = addDto.Phone,
                    Fax = addDto.Fax,
                    Creation_Date = addDto.CreationDate,
                    Creation_User = addDto.CreationUser,
                };
                this.shopDB.Customers.Add(customers);
                this.shopDB.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error guardando al cliente", ex.ToString());

            }
        }

        public void UpdateCustomer(CustomersUpdateDto updateDto)
        {
            try
            {
                if (updateDto is null)
                    throw new CustomerException("El objeto cliente no puede ser nulo.");


                Customers customers = this.shopDB.Customers.Find(updateDto.CustID);


                if (customers is null)
                    throw new CustomerException("El cliente no se encuentra registrado.");


                customers.CompanyName = updateDto.CompanyName;
                customers.ContactName = updateDto.ContactName;
                customers.ContactTitle = updateDto.ContactTitle;
                customers.Address = updateDto.Address;
                customers.City = updateDto.City;
                customers.Email = updateDto.Email;
                customers.Region = updateDto.Region;
                customers.PostalCode = updateDto.PostalCode;
                customers.Country = updateDto.Country;
                customers.Phone = updateDto.Phone;
                customers.Fax = updateDto.Fax;
                customers.Modify_User = updateDto.ModifyUser;
                customers.Modify_Date = updateDto.ModifyDate;

                this.shopDB.Customers.Update(customers);
                this.shopDB.SaveChanges();

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error actualizando el cliente", ex.ToString());

            }
        }
    }
}
