using Blazor.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Shared.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Game> Games { get; set; } 
}