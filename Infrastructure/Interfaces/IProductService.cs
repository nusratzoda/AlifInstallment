using Domain.Dtos;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Task<AddProductDto> AddProduct(AddProductDto productDto);
    Task<bool> DeleteProduct(int id);
    Task<AddProductDto> GetProductById(int id);
    Task<List<GetProductDto>> GetProducts();
    Task<AddProductDto> UpdateProduct(AddProductDto productDto);
}