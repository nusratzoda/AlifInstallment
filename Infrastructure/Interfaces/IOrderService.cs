using Domain.Dtos;

namespace Infrastructure.Interfaces;

public interface IOrderService
{
    Task<AddOrderDto> AddOrder(AddOrderDto orderDto);
    Task<bool> DeleteOrder(int id);
    Task<AddOrderDto> GetOrderById(int id);
    Task<List<GetOrderDto>> GetOrders();
    Task<AddOrderDto> UpdateOrder(AddOrderDto orderDto);
}