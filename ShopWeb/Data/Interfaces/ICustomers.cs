using ShopWeb.Data.Dtos;

namespace ShopWeb.Data.Interfaces
{
    public interface ICustomers
    {
        void SaveCustomer(CustomersAddDto addDto);
        void RemoveCustomer(CustomersRemoveDto removeDto);
        void UpdateCustomer(CustomersUpdateDto updateDto);
        List<CustomersAddDto> GetCustomers();
        CustomersAddDto GetCustomerById(int customerId);
    }
}
