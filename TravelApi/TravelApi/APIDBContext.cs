using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TravelApi
{
    
        public class APIDBContext : DbContext
        {
            public APIDBContext(DbContextOptions<APIDBContext> options) : base(options)
            {
                    
            }

            public DbSet<Landmark> landmarks { get; set; }
            //public DbSet<BankAccount> BankAccounts { get; set; }

        }
    
}
