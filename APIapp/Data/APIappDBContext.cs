using Microsoft.EntityFrameworkCore;
using APIapp.Models;

namespace APIapp.Data
{
    public class APIappDBContext : DbContext{
            public APIappDBContext (DbContextOptions<APIappDBContext> options) : base (options) {

             }
            public DbSet<appCommands> Commands { get; set; }
    }
}