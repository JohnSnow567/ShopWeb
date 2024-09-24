using ShopWeb.Data.Dtos;

namespace ShopWeb.Data.Interfaces
{
    public interface ICategories
    {
        void SaveCategory(CategoriesAddDto addDto);
        void RemoveCategory(CategoriesRemoveDto removeDto);
        void UpdateCategory(CategoriesUpdateDto updateDto);
        List<CategoriesAddDto> GetCategories();
        CategoriesAddDto GetCategoryById(int categoryId);
    }
}
