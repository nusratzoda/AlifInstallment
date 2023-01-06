using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly DataContext _context;
    public ProductService(DataContext context)
    {
        _context = context;
    }

    public async Task<AddProductDto> AddProduct(AddProductDto productDto)
    {
        var product = new Product()
        {
            ProductName = productDto.ProductName,
            Price = productDto.Price,
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        productDto.Id = product.Id;


        var productCreated = await GetProductById(product.Id);
        return productCreated;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(e => e.Id == id);

        if (product == null)
        {
            return false;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<GetProductDto>> GetProducts()
    {
        var products = await _context.Products
            .Select(cu => new GetProductDto()
            {
                Id = cu.Id,
                ProductName = cu.ProductName,
                Price = cu.Price,
            }).ToListAsync();
        return products;
    }

    public async Task<AddProductDto> GetProductById(int id)
    {
        var product = await _context.Products
            .Select(cu => new AddProductDto()
            {
                Id = cu.Id,
                ProductName = cu.ProductName,
                Price = cu.Price,
            }).FirstOrDefaultAsync(tu => tu.Id == id);
        return product;
    }

    public async Task<AddProductDto> UpdateProduct(AddProductDto productDto)
    {

        var product = await _context.Products.FirstOrDefaultAsync(pa => pa.Id == productDto.Id);

        if (product == null)
        {
            return null;
        }

        product.ProductName = productDto.ProductName;
        product.Price = productDto.Price;

        await _context.SaveChangesAsync();

        var productUpdated = await GetProductById(product.Id);
        return productUpdated;
    }
}