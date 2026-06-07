using Microsoft.EntityFrameworkCore;
using ServisTalep.Api.Models;

namespace ServisTalep.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ServiceRequest> ServiceRequests { get; set; }
}