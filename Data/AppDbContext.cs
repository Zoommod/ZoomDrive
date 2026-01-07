using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using ZoomDrive.web.Controllers;
using ZoomDrive.web.Models;

namespace ZoomDrive.web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<ArquivoModel> Arquivos { get; set; }
}
