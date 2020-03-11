using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingWebSearch.Entities;
using Microsoft.EntityFrameworkCore;


namespace BingWebSearch
{
    public class BingWebSearchContext : DbContext
    {
        public BingWebSearchContext(DbContextOptions<BingWebSearchContext> options) : base(options) { }
        public DbSet<value>  SaveUrlInfo{ get; set; }

    }
}
