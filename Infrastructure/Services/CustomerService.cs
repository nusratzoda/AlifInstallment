using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CustomerService : ICustomerService
{
    private readonly DataContext _context;
    public CustomerService(DataContext context)
    {
        _context = context;
    }

    public async Task<AddCustomerDto> AddCustomer(AddCustomerDto customerDto)
    {
        var customer = new Customer
        {
            CustomerName = customerDto.CustomerName,
            PhoneNumber = customerDto.PhoneNumber,
        };

        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();

        customerDto.Id = customer.Id;


        var customerCreated = await GetCustomerById(customer.Id);
        return customerCreated;
    }

    public async Task<bool> DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(e => e.Id == id);

        if (customer == null)
        {
            return false;
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<GetCustomerDto>> GetCustomers()
    {
        var customers = await _context.Customers
            .Select(cu => new GetCustomerDto()
            {
                Id = cu.Id,
                CustomerName = cu.CustomerName,
                PhoneNumber = cu.PhoneNumber,
                Orders =
                                          (
                                              from or in _context.Orders
                                              join ins in _context.Installments on or.InstallmentId equals ins.Id
                                              where cu.Id == or.CustomerId
                                              select new GetOrderDto()
                                              {
                                                  Id = or.Id,
                                                  CustomerId = cu.Id,
                                                  InstallmentId = ins.Id,
                                                  CustomerName = cu.CustomerName
                                              }
                                              ).ToList()
            }).ToListAsync();
        return customers;
    }

    public async Task<AddCustomerDto> GetCustomerById(int id)
    {
        var customer = await _context.Customers
            .Select(cu => new AddCustomerDto()
            {
                Id = cu.Id,
                CustomerName = cu.CustomerName,
                PhoneNumber = cu.PhoneNumber,
            }).FirstOrDefaultAsync(tu => tu.Id == id);
        return customer;
    }

    public async Task<AddCustomerDto> UpdateCustomer(AddCustomerDto customerDto)
    {

        var customer = await _context.Customers.FirstOrDefaultAsync(pa => pa.Id == customerDto.Id);

        if (customer == null)
        {
            return null;
        }

        customer.CustomerName = customerDto.CustomerName;
        customer.PhoneNumber = customerDto.PhoneNumber;

        await _context.SaveChangesAsync();

        var customerUpdated = await GetCustomerById(customer.Id);
        return customerUpdated;
    }
}