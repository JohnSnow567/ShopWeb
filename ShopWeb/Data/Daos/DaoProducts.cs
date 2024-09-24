using ShopWeb.Data.Context;
using ShopWeb.Data.Dtos;
using ShopWeb.Data.Entities;
using ShopWeb.Data.Exceptions;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Data.Daos
{
    public class DaoProducts : IProducts
    {
        private readonly ShopDBContext shopDB;
        private readonly ILogger<DaoProducts> logger;
        public DaoProducts(ShopDBContext shopDB,
                          ILogger<DaoProducts> logger)
        {
            this.shopDB = shopDB;
            this.logger = logger;

        }
        public ProductsAddDto GetProductById(int productId)
        {
            ProductsAddDto productResult = new ProductsAddDto();
            try
            {
                var product = this.shopDB.Products.Find(productId);

                if (product is null)
                    throw new ProductException("El producto no se encuentra registrado.");


                productResult.ProductID = product.ProductID;
                productResult.ProductName = product.ProductName;
                productResult.SupplierID = product.SupplierID;
                productResult.CategoryID = product.CategoryID;
                productResult.UnitPrice = product.UnitPrice;
                productResult.Discontinued = product.Discontinued;
                productResult.CreationDate = product.Creation_Date;
                productResult.CreationUser = product.Creation_User;


            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo el producto", ex.ToString());
            }
            return productResult;
        }

        public List<ProductsAddDto> GetProducts()
        {
            List<ProductsAddDto> products = new List<ProductsAddDto>();
            try
            {
                products = (from prd in this.shopDB.Products
                              where prd.Deleted == false
                              orderby prd.Creation_Date descending
                              select new ProductsAddDto()
                              {
                                  ProductID = prd.ProductID,
                                  ProductName = prd.ProductName,
                                  SupplierID = prd.SupplierID,
                                  CategoryID = prd.CategoryID,
                                  UnitPrice = prd.UnitPrice,
                                  Discontinued = prd.Discontinued,
                                  CreationDate = prd.Creation_Date,
                                  CreationUser = prd.Creation_User,
                              }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los productos", ex.ToString());
            }
            return products;
        }

        public void RemoveProduct(ProductsRemoveDto removeDto)
        {
            try
            {
                if (removeDto is null)
                    throw new ProductException("El objeto producto no puede ser nulo.");


                var category = this.shopDB.Products.Find(removeDto.ProductID);

                if (category is null)
                    throw new ProductException("El producto no se encuentra registrado.");

                category.Deleted = true;
                category.Delete_Date = removeDto.DeletedDate;
                category.Delete_User = removeDto.UserDeleted;

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error removiendo el producto", ex.ToString());
            }
        }

        public void SaveProduct(ProductsAddDto addDto)
        {
            try
            {
                if (addDto is null)
                    throw new ProductException("El objeto producto no puede ser nulo.");

                //if (this.shopDB.Products.Any(ctgo => ctgo.ProductName == addDto.ProductName))
                //    throw new ProductException("El objeto producto no puede ser nulo.");


                Products products = new Products()
                {
                    ProductName = addDto.ProductName,
                    SupplierID = addDto.SupplierID,
                    CategoryID = addDto.CategoryID,
                    UnitPrice = addDto.UnitPrice,
                    Discontinued = addDto.Discontinued,
                    Creation_Date = addDto.CreationDate,
                    Creation_User = addDto.CreationUser,
                };
                this.shopDB.Products.Add(products);
                this.shopDB.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error guardando al producto", ex.ToString());

            }
        }

        public void UpdateProduct(ProductsUpdateDto updateDto)
        {
            try
            {
                if (updateDto is null)
                    throw new ProductException("El objeto producto no puede ser nulo.");


                Products products = this.shopDB.Products.Find(updateDto.ProductID);


                if (products is null)
                    throw new ProductException("El producto no se encuentra registrado.");


                products.ProductName = updateDto.ProductName;
                products.SupplierID = updateDto.SupplierID;
                products.CategoryID = updateDto.CategoryID;
                products.UnitPrice = updateDto.UnitPrice;
                products.Discontinued = updateDto.Discontinued;
                products.Modify_User = updateDto.ModifyUser;
                products.Modify_Date = updateDto.ModifyDate;

                this.shopDB.Products.Update(products);
                this.shopDB.SaveChanges();

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error actualizando al producto", ex.ToString());

            }
        }
    }
}
