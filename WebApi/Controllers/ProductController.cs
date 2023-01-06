using Domain.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<List<GetProductDto>> GetProducts()
    {
        return await _productService.GetProducts();
    }

    [HttpPost]
    public async Task<AddProductDto> AddProduct(AddProductDto productDto)
    {
        return await _productService.AddProduct(productDto);
    }

    [HttpPut]
    public async Task<AddProductDto> UpdateProduct(AddProductDto productDto)
    {
        return await _productService.UpdateProduct(productDto);
    }

    [HttpDelete]
    public async Task<bool> DeleteProduct(int id)
    {
        return await _productService.DeleteProduct(id);
    }
}
