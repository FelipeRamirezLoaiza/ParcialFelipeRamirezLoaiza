using Microsoft.EntityFrameworkCore;
using ParcialFelipeRamirezLoaiza.DAL.Entities;

namespace ParcialFelipeRamirezLoaiza.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
