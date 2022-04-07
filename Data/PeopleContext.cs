using LataPrzestepne.Models;
using Microsoft.EntityFrameworkCore;

namespace LataPrzestepne.Data
{
    public class PeopleContext:DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> Person { get; set; }
    }
}
