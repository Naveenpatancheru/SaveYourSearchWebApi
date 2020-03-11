using Microsoft.EntityFrameworkCore;
using SaveYourSearchAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaveYourSearchAPI.DbContexts
{
    public class SaveYourSearchContext: DbContext
    {
        public SaveYourSearchContext(DbContextOptions<SaveYourSearchContext> options) :base(options) { }
        public DbSet<SavedImage> SavedImages { get; set; }
        public DbSet<SavedImageTag> SavedImageTags { get; set; }
    }
   
}
