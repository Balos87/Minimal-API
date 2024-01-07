using Microsoft.EntityFrameworkCore;
using LabbProjektApi.Models;
using LabbProjektApi.Connections;
using LabbProjektApi.Data;
using System.Collections;
using System.Data.SqlTypes;
using System.Linq;


namespace LabbProjektApi.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<InterestLink> InterestLinks { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }


    }
}
