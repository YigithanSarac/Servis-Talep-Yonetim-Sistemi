using Microsoft.EntityFrameworkCore;
using ServisTalep.Api.Data;
using ServisTalep.Api.DTOs;
using ServisTalep.Api.Models;

namespace ServisTalep.Api.Services;

public class RequestService : IRequestService
{
    private readonly AppDbContext _context;

    public RequestService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceRequest> CreateAsync(CreateServiceRequestDto dto)
    {
        var request = new ServiceRequest
        {
            CustomerName = dto.CustomerName,
            DeviceName = dto.DeviceName,
            Description = dto.Description,
            Status = "New",
            CreatedDate = DateTime.UtcNow
        };

        _context.ServiceRequests.Add(request);
        await _context.SaveChangesAsync();

        return request;
    }

    public async Task<List<ServiceRequest>> GetAllAsync(RequestQueryDto queryDto)
{
    var query = _context.ServiceRequests.AsQueryable();

    if (!string.IsNullOrWhiteSpace(queryDto.Search))
    {
        query = query.Where(x =>
            x.CustomerName.Contains(queryDto.Search) ||
            x.DeviceName.Contains(queryDto.Search) ||
            x.Description.Contains(queryDto.Search));
    }

    if (!string.IsNullOrWhiteSpace(queryDto.Status))
    {
        query = query.Where(x => x.Status == queryDto.Status);
    }

    if (queryDto.Page < 1)
        queryDto.Page = 1;

    if (queryDto.PageSize < 1)
        queryDto.PageSize = 10;

    if (queryDto.PageSize > 100)
        queryDto.PageSize = 100;

    return await query
        .OrderByDescending(x => x.CreatedDate)
        .Skip((queryDto.Page - 1) * queryDto.PageSize)
        .Take(queryDto.PageSize)
        .ToListAsync();
}
    public async Task<ServiceRequest?> GetByIdAsync(int id)
    {
        return await _context.ServiceRequests.FindAsync(id);
    }

    public async Task<ServiceRequest?> UpdateStatusAsync(int id, UpdateStatusDto dto)
    {
        var request = await _context.ServiceRequests.FindAsync(id);

        if (request == null)
            return null;

        request.Status = dto.Status;

        await _context.SaveChangesAsync();

        return request;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var request = await _context.ServiceRequests.FindAsync(id);

        if (request == null)
            return false;

        _context.ServiceRequests.Remove(request);
        await _context.SaveChangesAsync();

        return true;
    }
}