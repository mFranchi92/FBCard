using FBCard.Models;
using Microsoft.EntityFrameworkCore;

namespace FBCard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CreditCard> CreditCard { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
