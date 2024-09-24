using ShopWeb.Data.Dtos;

namespace ShopWeb.Data.Interfaces
{
    public interface ISuppliers
    {
        void SaveSupplier(SuppliersAddDto addDto);
        void RemoveSupplier(SuppliersRemoveDto removeDto);
        void UpdateSupplier(SuppliersUpdateDto updateDto);
        List<SuppliersAddDto> GetSuppliers();
        SuppliersAddDto GetSupplierById(int supplierId);
    }
}
