using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models
{
    public class ContextRes : DbContext
    {
        public ContextRes(DbContextOptions<ContextRes> options):base(options)
        {

        }
        public DbSet<RecettesClass> recettes { get;set; }
    }
}
