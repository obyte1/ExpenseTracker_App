using CRUD_.NET5.Models;
using Microsoft.EntityFrameworkCore;
 

namespace CRUD_.NET5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Item> items{ get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public DbSet<UserAccount> userAccount { get; set; }
        public DbSet<ReservationModel> reservationModel { get; set; }
    }
}
