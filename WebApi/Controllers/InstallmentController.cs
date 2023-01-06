using Domain.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstallmentController : Controller
{
        private readonly IInstallmentService _installmentService;
        public InstallmentController(IInstallmentService installmentService)
        {
            _installmentService = installmentService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<List<GetInstallmentDto>> GetInstallments()
        {
            return await _installmentService.GetInstallments();
        }

        [HttpPost]
        public async Task<AddInstallmentDto> AddInstallment(AddInstallmentDto installmentDto)
        {
            return await _installmentService.AddInstallment(installmentDto);
        }

        [HttpPut]
        public async Task<AddInstallmentDto> UpdateInstallment(AddInstallmentDto installmentDto)
        {
            return await _installmentService.UpdateInstallment(installmentDto);
        }

        [HttpDelete]
        public async Task<bool> DeleteInstallment(int id)
        {
            return await _installmentService.DeleteInstallment(id);
        }
}
