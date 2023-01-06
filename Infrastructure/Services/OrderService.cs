using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly DataContext _context;
    public OrderService(DataContext context)
    {
        _context = context;
    }

    public async Task<AddOrderDto> AddOrder(AddOrderDto orderDto)
    {
        var order = new Order
        {
            CustomerId = orderDto.CustomerId,
            InstallmentId = orderDto.InstallmentId,
        };

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        orderDto.Id = order.Id;


        var orderCreated = await GetOrderById(order.Id);
        return orderCreated;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(e => e.Id == id);

        if (order == null)
        {
            return false;
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<GetOrderDto>> GetOrders()
    {
        var orders = await (from or in _context.Orders
                            join cu in _context.Customers
                                on or.CustomerId equals cu.Id
                            join ins in _context.Installments
                                on or.InstallmentId equals ins.Id
                            select new GetOrderDto()
                            {
                                Id = or.Id,
                                CustomerName = cu.CustomerName,
                                EndInstallment = ins.EndInstallment,
                            }).ToListAsync();
        return orders;
    }

    public async Task<AddOrderDto> GetOrderById(int id)
    {
        var order = await _context.Orders
            .Select(or => new AddOrderDto()
            {
                Id = or.Id,
                CustomerId = or.CustomerId,
                InstallmentId = or.InstallmentId,
            }).FirstOrDefaultAsync(tu => tu.Id == id);
        return order;
    }

    public async Task<AddOrderDto> UpdateOrder(AddOrderDto orderDto)
    {

        var order = await _context.Orders.FirstOrDefaultAsync(pa => pa.Id == orderDto.Id);

        if (order == null)
        {
            return null;
        }

        order.CustomerId = orderDto.CustomerId;
        order.InstallmentId = orderDto.InstallmentId;

        await _context.SaveChangesAsync();

        var orderUpdated = await GetOrderById(order.Id);
        return orderUpdated;
    }
}
