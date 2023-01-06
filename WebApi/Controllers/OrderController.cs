using Domain.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<List<GetOrderDto>> GetOrders()
    {
        return await _orderService.GetOrders();
    }

    [HttpPost]
    public async Task<AddOrderDto> AddOrder(AddOrderDto orderDto)
    {
        return await _orderService.AddOrder(orderDto);
    }

    [HttpPut]
    public async Task<AddOrderDto> UpdateOrder(AddOrderDto orderDto)
    {
        return await _orderService.UpdateOrder(orderDto);
    }

    [HttpDelete]
    public async Task<bool> DeleteOrder(int id)
    {
        return await _orderService.DeleteOrder(id);
    }
}
