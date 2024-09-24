using ShopWeb.Data.Dtos;

namespace ShopWeb.Data.Interfaces
{
    public interface IProducts
    {
        void SaveProduct(ProductsAddDto addDto);
        void RemoveProduct(ProductsRemoveDto removeDto);
        void UpdateProduct(ProductsUpdateDto updateDto);
        List<ProductsAddDto> GetProducts();
        ProductsAddDto GetProductById(int productId);
    }
}
