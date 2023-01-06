using Domain.Dtos;

namespace Infrastructure.Interfaces;

public interface IInstallmentService
{
    Task<AddInstallmentDto> AddInstallment(AddInstallmentDto installmentDto);
    Task<bool> DeleteInstallment(int id);
    Task<AddInstallmentDto> GetInstallmentById(int id);
    Task<List<GetInstallmentDto>> GetInstallments();
    Task<AddInstallmentDto> UpdateInstallment(AddInstallmentDto installmentDto);
}