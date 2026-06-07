using ServisTalep.Api.DTOs;
using ServisTalep.Api.Models;

namespace ServisTalep.Api.Services;

public interface IRequestService
{
    Task<ServiceRequest> CreateAsync(CreateServiceRequestDto dto);
    Task<List<ServiceRequest>> GetAllAsync(RequestQueryDto queryDto);
    Task<ServiceRequest?> GetByIdAsync(int id);
    Task<ServiceRequest?> UpdateStatusAsync(int id, UpdateStatusDto dto);
    Task<bool> DeleteAsync(int id);
}