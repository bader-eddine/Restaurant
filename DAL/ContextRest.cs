using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public class ContextRest : DbContext
    {
        public ContextRest(DbContextOptions<ContextRest> options) : base(options)
        {

        }
        public DbSet<Recette> recette { get; set; }
    }
}
