using Domain.Dtos;

namespace Infrastructure.Interfaces;

public interface ICustomerService
{
    Task<AddCustomerDto> AddCustomer(AddCustomerDto customerDto);
    Task<bool> DeleteCustomer(int id);
    Task<AddCustomerDto> GetCustomerById(int id);
    Task<List<GetCustomerDto>> GetCustomers();
    Task<AddCustomerDto> UpdateCustomer(AddCustomerDto customerDto);
}
