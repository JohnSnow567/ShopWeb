using ShopWeb.Data.Context;
using ShopWeb.Data.Dtos;
using ShopWeb.Data.Entities;
using ShopWeb.Data.Exceptions;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Data.Daos
{
    public class DaoCategories : ICategories
    {
        private readonly ShopDBContext shopDB;
        private readonly ILogger<DaoCategories> logger;
        public DaoCategories(ShopDBContext shopDB,
                          ILogger<DaoCategories> logger) 
        {
            this.shopDB = shopDB;
            this.logger = logger;

        }

        public List<CategoriesAddDto> GetCategories()
        {
            List<CategoriesAddDto> categories = new List<CategoriesAddDto>();
            try
            {
                categories = (from ctgo in this.shopDB.Categories
                               where ctgo.Deleted == false
                               orderby ctgo.Creation_Date descending
                               select new CategoriesAddDto()
                               {
                                   CategoryID = ctgo.CategoryID,
                                   CategoryName = ctgo.CategoryName,
                                   Description = ctgo.Description,
                                   CreationDate = ctgo.Creation_Date,
                                   CreationUser = ctgo.Creation_User,
                               }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los departamentos", ex.ToString());
            }
            return categories;
        }

        public CategoriesAddDto GetCategoryById(int categoryId)
        {
            CategoriesAddDto categoryResult = new CategoriesAddDto();
            try
            {
                var category = this.shopDB.Categories.Find(categoryId);

                if (category is null)
                    throw new CategoryException("La categoria no se encuentra registrada.");


                categoryResult.CategoryID = category.CategoryID;
                categoryResult.CategoryName = category.CategoryName;
                categoryResult.Description = category.Description;
                categoryResult.CreationDate = category.Creation_Date;
                categoryResult.CreationUser = category.Creation_User;



            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo la categoria", ex.ToString());
            }
            return categoryResult;
        }

        public void RemoveCategory(CategoriesRemoveDto removeDto)
        {
            try
            {
                if (removeDto is null)
                    throw new CategoryException("El objeto categoria no puede ser nulo.");


                var category = this.shopDB.Categories.Find(removeDto.CategoryID);

                if (category is null)
                    throw new CategoryException("La categoria no se encuentra registrada.");

                category.Deleted = true;
                category.Delete_Date = removeDto.DeletedDate;
                category.Delete_User = removeDto.UserDeleted;

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error removiendo la categoria", ex.ToString());
            }
        }

        public void SaveCategory(CategoriesAddDto addDto)
        {
            try
            {
                if (addDto is null)
                    throw new CategoryException("El objeto categoria no puede ser nulo.");

                //if (this.shopDB.Categories.Any(ctgo => ctgo.CategoryName == addDto.CategoryName))
                //    throw new CategoryException("El objeto categoria no puede ser nulo.");


                Categories categories = new Categories()
                {
                    CategoryName = addDto.CategoryName,
                    Description = addDto.Description,
                    Creation_Date = addDto.CreationDate,
                    Creation_User = addDto.CreationUser,
                };
                this.shopDB.Categories.Add(categories);
                this.shopDB.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error guardando la categoria", ex.ToString());

            }
        }

        public void UpdateCategory(CategoriesUpdateDto updateDto)
        {
            try
            {
                if (updateDto is null)
                    throw new CategoryException("El objeto categoria no puede ser nulo.");


                Categories categories = this.shopDB.Categories.Find(updateDto.CategoryID);


                if (categories is null)
                    throw new CategoryException("La categoria no se encuentra registrada.");


                categories.CategoryName = updateDto.CategoryName;
                categories.Description = updateDto.Description;
                categories.Modify_User = updateDto.ModifyUser;
                categories.Modify_Date = updateDto.ModifyDate;

                this.shopDB.Categories.Update(categories);
                this.shopDB.SaveChanges();

            }
            catch (Exception ex)
            {

                this.logger.LogError("Error actualizando la categoria", ex.ToString());

            }
        }
    }
}
