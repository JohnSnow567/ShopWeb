using ShopWeb.Data.Context;
using ShopWeb.Data.Dtos;
using ShopWeb.Data.Entities;
using ShopWeb.Data.Exceptions;
using ShopWeb.Data.Interfaces;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;

namespace ShopWeb.Data.Daos
{
    public class DaoSuppliers : ISuppliers
    {
        private readonly ShopDBContext shopDB;
        private readonly ILogger<DaoSuppliers> logger;
        public DaoSuppliers(ShopDBContext shopDB,
                          ILogger<DaoSuppliers> logger)
        {
            this.shopDB = shopDB;
            this.logger = logger;

        }
        public SuppliersAddDto GetSupplierById(int supplierId)
        {
            SuppliersAddDto supplierResult = new SuppliersAddDto();
            try
            {
                var supplier = this.shopDB.Suppliers.Find(supplierId);

                if (supplier is null)
                    throw new SupplierException("El suplidor no se encuentra registrado.");


                supplierResult.SupplierID = supplier.SupplierID;
                supplierResult.CompanyName = supplier.CompanyName;
                supplierResult.ContactName = supplier.ContactName;
                supplierResult.ContactTitle = supplier.ContactTitle;
                supplierResult.Address = supplier.Address;
                supplierResult.City = supplier.City;
                supplierResult.Region = supplier.Region;
                supplierResult.PostalCode = supplier.PostalCode;
                supplierResult.Country = supplier.Country;
                supplierResult.Phone = supplier.Phone;
                supplierResult.Fax = supplier.Fax;
                supplierResult.CreationUser = supplier.Creation_User;
                supplierResult.CreationDate = supplier.Creation_Date;
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo la categoria", ex.ToString());
            }
            return supplierResult;
        }

        public List<SuppliersAddDto> GetSuppliers()
        {
            List<SuppliersAddDto> suppliers = new List<SuppliersAddDto>();
            try
            {
                suppliers = (from spl in this.shopDB.Suppliers
                             where spl.Deleted == false
                             orderby spl.Creation_Date descending
                             select new SuppliersAddDto()
                             {
                                 SupplierID = spl.SupplierID,
                                 CompanyName = spl.CompanyName,
                                 ContactName = spl.ContactName,
                                 ContactTitle = spl.ContactTitle,
                                 Address = spl.Address,
                                 City = spl.City,
                                 Region = spl.Region,
                                 PostalCode = spl.PostalCode,
                                 Country = spl.Country,
                                 Phone = spl.Phone,
                                 Fax = spl.Fax,
                                 CreationDate = spl.Creation_Date,
                                 CreationUser = spl.Creation_User,
                             }).ToList();
            }


            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los suplidores", ex.ToString());
            }
            return suppliers;
        }

        public void RemoveSupplier(SuppliersRemoveDto removeDto)
        {
            try
            {
                if (removeDto is null)
                    throw new SupplierException("El objeto suplidor no puede ser nulo.");


                var supplier = this.shopDB.Suppliers.Find(removeDto.SupplierID);

                if (supplier is null)
                    throw new SupplierException("El suplidor no se encuentra registrado.");

                supplier.Deleted = true;
                supplier.Delete_Date = removeDto.DeletedDate;
                supplier.Delete_User = removeDto.UserDeleted;

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error removiendo el suplidor", ex.ToString());
            }
        }

        public void SaveSupplier(SuppliersAddDto addDto)
        {
            try
            {
                if (addDto is null)
                    throw new SupplierException("El objeto suplidor no puede ser nulo.");

                //if (this.shopDB.Suppliers.Any(spl => spl.CompanyName == addDto.CompanyName))
                //    throw new SupplierException("El objeto suplidor no puede ser nulo.");


                Suppliers suppliers = new Suppliers()
                {
                    CompanyName = addDto.CompanyName,
                    ContactName = addDto.ContactName,
                    ContactTitle = addDto.ContactTitle,
                    Address = addDto.Address,
                    City = addDto.City,
                    Region = addDto.Region,
                    PostalCode = addDto.PostalCode,
                    Country = addDto.Country,
                    Phone = addDto.Phone,
                    Fax = addDto.Fax,
                    Creation_Date = addDto.CreationDate,
                    Creation_User = addDto.CreationUser,
                };
                this.shopDB.Suppliers.Add(suppliers);
                this.shopDB.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error guardando al suplidor", ex.ToString());

            }
        }

        public void UpdateSupplier(SuppliersUpdateDto updateDto)
        {
            try
            {
                if (updateDto is null)
                    throw new SupplierException("El objeto suplidor no puede ser nulo.");


                Suppliers suppliers = this.shopDB.Suppliers.Find(updateDto.SupplierID);


                if (suppliers is null)
                    throw new SupplierException("El suplidor no se encuentra registrado.");


                suppliers.CompanyName = updateDto.CompanyName;
                suppliers.ContactName = updateDto.ContactName;
                suppliers.ContactTitle = updateDto.ContactTitle;
                suppliers.Address = updateDto.Address;
                suppliers.City = updateDto.City;
                suppliers.Region = updateDto.Region;
                suppliers.PostalCode = updateDto.PostalCode;
                suppliers.Country = updateDto.Country;
                suppliers.Phone = updateDto.Phone;
                suppliers.Fax = updateDto.Fax;
                suppliers.Modify_User = updateDto.ModifyUser;
                suppliers.Modify_Date = updateDto.ModifyDate;

                this.shopDB.Suppliers.Update(suppliers);
                this.shopDB.SaveChanges();

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error actualizando el suplidor", ex.ToString());

            }
        }
    }
}
