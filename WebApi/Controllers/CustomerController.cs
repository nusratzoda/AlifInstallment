using Domain.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

     [HttpGet]
     [Authorize(AuthenticationSchemes = "Bearer")]
     public async Task<List<GetCustomerDto>> GetCustomers()
     {
         return await _customerService.GetCustomers();
     }

     [HttpPost]
     public async Task<AddCustomerDto> AddCustomer(AddCustomerDto customerDto)
     {
         return await _customerService.AddCustomer(customerDto);
     }

     [HttpPut]
     public async Task<AddCustomerDto> UpdateCustomer(AddCustomerDto customerDto)
    {
         return await _customerService.UpdateCustomer(customerDto);
     }

     [HttpDelete]
     public async Task<bool> DeleteCustomer(int id)
     {
         return await _customerService.DeleteCustomer(id);
     }
}
