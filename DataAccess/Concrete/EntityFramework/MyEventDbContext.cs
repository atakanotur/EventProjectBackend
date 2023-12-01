using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class MyEventDbContext : DbContext
    {
        //Server=hostsql1.isimtescil.net;Database=EventProject;User Id = atakan; Password=xvH317x&1;
        //Server = (localdb)\mssqllocaldb; Database = EventProject; Trusted_Connection = True;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=93.89.230.2;Initial Catalog=EventProject;Integrated Security=False;User ID=atakan; Password=xvH317x&1;Connect Timeout=30;Encrypt=False;Packet Size=8192", options =>
            {
                options.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null);
            });
        }

        public DbSet<MyEvent> MyEvents { get; set; }
        public DbSet<MyEventType> MyEventTypes { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
